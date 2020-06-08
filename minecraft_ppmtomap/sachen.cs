using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace minecraft_ppmtomap
{
    public partial class Form1
    {
        public class globalvars
        {
            public static string pathOpen = string.Empty;
            public static string pathSave = string.Empty;
            public static string pathSaveLockedMap = string.Empty;

            public static int startMap = 0;

            public static int y_start = 130;
            public static int h_max = 240; //+- von y_start

            public static readonly int shade_multi_flat = 220;
            public static readonly int shade_multi_dark = 180;
            public static readonly int shade_multi_superDark = 135; //nur bei locked map
            public static readonly int shade_div = 255;
            public static readonly int command_block_max = 31000;

            public static readonly int colordata_arraysize_x = 52;
            public static string[,] colordata = 
            {
            {"---,---,---", " ", " ", " ", "minecraft:air"},
            {"127,178,56",  " ", " ", " ", "minecraft:slime_block"},
            {"247,233,163", " ", " ", " ", "minecraft:birch_planks"},
            {"199,199,199", " ", " ", " ", "minecraft:cobweb"},
            {"255,0,0",     " ", " ", " ", "minecraft:redstone_block"},
            {"160,160,255", " ", " ", " ", "minecraft:packed_ice"},
            {"167,167,167", " ", " ", " ", "minecraft:iron_block"},
            {"0,124,0",     " ", " ", " ", "minecraft:oak_leaves[persistent=true]"},
            {"255,255,255", " ", " ", " ", "minecraft:white_concrete"},
            {"164,168,184", " ", " ", " ", "minecraft:clay"},
            {"151,109,77",  " ", " ", " ", "minecraft:jungle_planks"},
            {"112,112,112", " ", " ", " ", "minecraft:cobblestone"},
            {"64,64,255",   " ", " ", " ", "minecraft:water"}, //nur bei locked map (auf die richtige Farbpalette achten!!!)
            {"143,119,72",  " ", " ", " ", "minecraft:oak_planks"},
            {"255,252,245", " ", " ", " ", "minecraft:diorite"},
            {"216,127,51",  " ", " ", " ", "minecraft:orange_concrete"},
            {"178,76,216",  " ", " ", " ", "minecraft:magenta_concrete"},
            {"102,153,216", " ", " ", " ", "minecraft:light_blue_concrete"},
            {"229,229,51",  " ", " ", " ", "minecraft:yellow_concrete"},
            {"127,204,25",  " ", " ", " ", "minecraft:lime_concrete"},
            {"242,127,165", " ", " ", " ", "minecraft:pink_concrete"},
            {"76,76,76",    " ", " ", " ", "minecraft:gray_concrete"},
            {"153,153,153", " ", " ", " ", "minecraft:light_gray_concrete"},
            {"76,127,153",  " ", " ", " ", "minecraft:cyan_concrete"},
            {"127,63,178",  " ", " ", " ", "minecraft:purple_concrete"},
            {"51,76,178",   " ", " ", " ", "minecraft:blue_concrete"},
            {"102,76,51",   " ", " ", " ", "minecraft:brown_concrete"},
            {"102,127,51",  " ", " ", " ", "minecraft:green_concrete"},
            {"153,51,51",   " ", " ", " ", "minecraft:red_concrete"},
            {"25,25,25",    " ", " ", " ", "minecraft:black_concrete"},
            {"250,238,77",  " ", " ", " ", "minecraft:gold_block"},
            {"92,219,213",  " ", " ", " ", "minecraft:diamond_block"},
            {"74,128,255",  " ", " ", " ", "minecraft:lapis_block"},
            {"0,217,58",    " ", " ", " ", "minecraft:emerald_block"},
            {"129,86,49",   " ", " ", " ", "minecraft:spruce_planks"},
            {"112,2,0",     " ", " ", " ", "minecraft:netherrack"},
            {"209,177,161", " ", " ", " ", "minecraft:white_terracotta"},
            {"159,82,36",   " ", " ", " ", "minecraft:orange_terracotta"},
            {"149,87,108",  " ", " ", " ", "minecraft:magenta_terracotta"},
            {"112,108,138", " ", " ", " ", "minecraft:light_blue_terracotta"},
            {"186,133,36",  " ", " ", " ", "minecraft:yellow_terracotta"},
            {"103,117,53",  " ", " ", " ", "minecraft:lime_terracotta"},
            {"160,77,78",   " ", " ", " ", "minecraft:pink_terracotta"},
            {"57,41,35",    " ", " ", " ", "minecraft:gray_terracotta"},
            {"135,107,98",  " ", " ", " ", "minecraft:light_gray_terracotta"},
            {"87,92,92",    " ", " ", " ", "minecraft:cyan_terracotta"},
            {"122,73,88",   " ", " ", " ", "minecraft:purple_terracotta"},
            {"76,62,92",    " ", " ", " ", "minecraft:blue_terracotta"},
            {"76,50,35",    " ", " ", " ", "minecraft:brown_terracotta"},
            {"76,82,42",    " ", " ", " ", "minecraft:green_terracotta"},
            {"142,60,46",   " ", " ", " ", "minecraft:red_terracotta"},
            {"37,22,16",    " ", " ", " ", "minecraft:black_terracotta"}
            };

            //quatsch
            public static int quatsch_count = 0;
            public static int checkBox_x_og = 0;
            public static int checkBox_y_og = 0;
            
            public static string[] quatsch = 
            {
            "Ne.",
            "Also das.",
            "Da will Jemand Ärger machen.",
            "Computer sagt Nein.",
            "Und dann hau ich dir auch noch eine rein...",
            "Machst du hier Ärger.",
            "Wir könnten zusammen Ärger machen.",
            "Halt Stop.",
            "Nein.",
            "You are fake news.",
            "Dat is Quatsch weißte.",
            "Wie heißt du schön.",
            "DU KANNST NICHT VORBEI!!!",
            "KAAAAAARRRLLLL",
            "Nenenenene"
            };
        }

        public void colorcalc()
        {
            for (int a = 1; a < globalvars.colordata_arraysize_x; a++)//start bei a=1 da 0=minecraft:air
            {
                char[] RGB_charArray = globalvars.colordata[a, 0].ToCharArray();
                char[] color_char = new char[3];
                int count = 0;
                int count2 = 0;
                string str = string.Empty;
                int[,] RGB_shades = new int[4,3];

                for (int aa = 0; aa < RGB_charArray.Length; aa++)//char array z.B. 200,210,233
                {
                    if (RGB_charArray[aa] == ',')//abtrennen nach ","
                    {
                        str = new string(color_char);//zu string
                        RGB_shades[0, count2] = int.Parse(str);//zu int in array
                        count = 0;
                        count2++;
                        for (int b = 0; b < 3; b++) 
                        {
                            color_char[b] = ' ';
                        }
                    }
                    else
                    {
                        color_char[count] = RGB_charArray[aa];
                        count++;                       
                    }
                }

                str = new string(color_char);
                RGB_shades[0, count2] = int.Parse(str);

                for (int aa = 0; aa < 3; aa++)
                {
                    RGB_shades[1, aa] = ((RGB_shades[0, aa] * globalvars.shade_multi_flat) / globalvars.shade_div);
                    RGB_shades[2, aa] = ((RGB_shades[0, aa] * globalvars.shade_multi_dark) / globalvars.shade_div);
                    RGB_shades[3, aa] = ((RGB_shades[0, aa] * globalvars.shade_multi_superDark) / globalvars.shade_div);
                }         

                for (int aa = 1; aa < 4; aa++)
                {
                    str = string.Empty;

                    for (count = 0; count < 3; count++)
                    {
                        str += RGB_shades[aa, count];
                        if (count < 2) str += ",";
                    }

                    globalvars.colordata[a, aa] = str;
                }

                //MessageBox.Show(
                //    globalvars.colordata[a,0] + "\n" +
                //    globalvars.colordata[a,1] + "\n" +
                //    globalvars.colordata[a,2] + "\n" +
                //    globalvars.colordata[a,3] + "\n"
                //);
            }
        }

        public void start_convert_old() //unused
        {
            if (fileok)
            {
                string[] readfile = System.IO.File.ReadAllLines(textBox_open.Text);
                //byte[] readfile2 = System.IO.File.ReadAllBytes(textBox_open.Text);
                if (readfile[0] == "P3")
                {
                    int x = 0;  //pic size x
                    int y = 0;  //pic size y                   

                    //read x/y values
                    string parameterline = readfile[2];
                    char[] chararray = parameterline.ToCharArray();
                    char[] temp = new char[5];
                    int parametercount = 0;

                    for (int a = 0; a < parameterline.Length; a++)
                    {
                        if (chararray[a] == ' ')
                        {
                            string str_x = new string(temp);
                            x = int.Parse(str_x);
                            parametercount = 0;

                            for (int aa = 0; aa < 5; aa++)
                            {
                                temp[aa] = ' ';
                            }
                        }
                        else
                        {
                            temp[parametercount] = chararray[a];
                            parametercount++;
                        }
                    }

                    string str_y = new string(temp);
                    y = int.Parse(str_y);

                    //color values "###,###,###" to array pic[,]
                    string[,] pic = new string[x, y];
                    string pixle = string.Empty;
                    int currentline = 4;

                    for (int yy = 0; yy < y; yy++)
                    {
                        for (int xx = 0; xx < x; xx++)
                        {
                            for (int p = 0; p < 3; p++)
                            {
                                pixle += readfile[currentline];
                                if (p < 2) pixle += ",";
                                currentline++;
                            }

                            pic[xx, yy] = pixle;
                            pixle = string.Empty;
                        }
                    }                  

                    //output
                    globalvars.y_start = int.Parse(textBox_y_start.Text);
                    globalvars.h_max = int.Parse(textBox_h_max.Text);

                    if (checkBox_schematic.Checked)
                    {
                        ConvertToMapV2(x, y, pic);
                    }
                    else
                    {
                        ConvertToMapV1(x, y, pic);
                    }
                }
                else
                {
                    fileok = false;
                    MessageBox.Show("Falsches Dateiformat... notieren sie sich den Fehlercode 01.");
                }
            }
        }

        public void start_convert()
        {
            if (fileok)
            {                
                byte[] readfile = System.IO.File.ReadAllBytes(globalvars.pathOpen);

                if ((readfile[0] == 'P') && (readfile[1] == '3'))
                {
                    int byteCount = 1;
                    int paraCount = 0;
                    int paraCountChar = 0;
                    char[] input = new char[5];                   
                    int x = 0;  //pic size x
                    int y = 0;  //pic size y                   
                    int brightness = 0;
                    string pixle = string.Empty;
                    int dataCount = 0;
                    int xx = 0;
                    int yy = 0;
                    char[] charsToTrim = { ' ', '\0' };

                    while (paraCount < 3)
                    {
                        byteCount++;

                        if (readfile[byteCount] == 35)//ASCII "#"
                        {
                            while (readfile[byteCount] != 10) byteCount++;
                        }
                        else if ((readfile[byteCount] >= 48) && (readfile[byteCount] <= 57))//ASCII "0"-"9"
                        {
                            input[paraCountChar] = Convert.ToChar(readfile[byteCount]);
                            paraCountChar++;
                        }
                        else if ((readfile[byteCount] == 32) | (readfile[byteCount] == 10))//ASCII space or line feed
                        {
                            if (paraCountChar > 0)
                            {
                                string str = new string(input);

                                switch (paraCount)
                                {
                                    case 0: x = int.Parse(str); break;
                                    case 1: y = int.Parse(str); break;
                                    case 2: brightness = int.Parse(str); break;
                                    default: break;
                                }

                                paraCount++;
                                paraCountChar = 0;
                                Array.Clear(input, 0, input.Length);
                            }
                        }
                    }

                    string[,] pic = new string[x, y];
                    //MessageBox.Show(x.ToString() + "\n" + y.ToString() + "\n" + brightness.ToString());
                    byteCount++;

                    while (byteCount < readfile.Length)
                    {                       
                        if (readfile[byteCount] == 35)//ASCII "#"
                        {
                            while (readfile[byteCount] != 10) byteCount++;
                        }
                        else if ((readfile[byteCount] >= 48) && (readfile[byteCount] <= 57))//ASCII "0"-"9"
                        {
                            input[paraCountChar] = Convert.ToChar(readfile[byteCount]);
                            paraCountChar++;
                        }
                        else if ((readfile[byteCount] == 32) | (readfile[byteCount] == 10))//ASCII space or line feed
                        {
                            if (paraCountChar > 0)
                            {                                
                                string strTemp = new string(input);
                                string str = strTemp.Trim(charsToTrim);

                                pixle += str;
                                if (dataCount < 2) pixle += ",";
                                dataCount++;

                                if (dataCount == 3)
                                {
                                    pic[xx, yy] = pixle;
                                    dataCount = 0;
                                    pixle = string.Empty;
                                    //MessageBox.Show(pic[xx, yy]);

                                    xx++;

                                    if (xx == x)
                                    {
                                        xx = 0;
                                        yy++;
                                    }
                                }                              

                                paraCountChar = 0;
                                Array.Clear(input, 0, input.Length);
                            }
                        }

                        byteCount++;
                    }

                    //output
                    globalvars.y_start = int.Parse(textBox_y_start.Text);
                    globalvars.h_max = int.Parse(textBox_h_max.Text);

                    if (checkBox_commandBlock.Checked)
                    {
                        ConvertToMapV1(x, y, pic);
                    }

                    if (checkBox_schematic.Checked)
                    {
                        ConvertToMapV2(x, y, pic);
                    }
                    
                    if (checkBox_lockedMap.Checked)
                    {
                        ConvertToMapV3(x, y, pic);
                    }
                }
                else
                {
                    fileok = false;
                    MessageBox.Show("Falsches Dateiformat... notieren sie sich den Fehlercode 01.");
                }
            }
        }

        public void ConvertToMapV1(int x, int y, string[,] pic)
        {
            progressFileMax = y;
            worker1.ReportProgress(0);//update progress bars

            int[,] h_map = new int[x, y];
            int previous_y = 0;
            int h_reset_count = 0;
            int h_low = 0;
            int h_high = 0;

            ArrayList cmd_lines = new ArrayList();
            string line = string.Empty;
            bool newline = true;
            bool firstline = true;

            for (int yy = 0; yy < y; yy++)//y of pic[,]
            {
                for (int xx = 0; xx < x; xx++)//x of pic[,]
                {
                    for (int a = 0; a < 3; a++)//shade of block in colordata[,] (nur 0-2, 3 nur bei locked map)
                    {
                        for (int b = 1; b < globalvars.colordata_arraysize_x; b++)//color of block colordata[,]
                        {
                            if (globalvars.colordata[b, a] == pic[xx, yy])
                            {
                                //h_map
                                if (yy == 0)
                                {
                                    h_map[xx, yy] = 0;
                                }
                                else
                                {
                                    previous_y = yy - 1;
                                    h_map[xx, yy] = h_map[xx, previous_y];
                                }

                                if (a == 0) h_map[xx, yy]++;
                                else if (a == 2) h_map[xx, yy]--;

                                if (Math.Abs(h_map[xx, yy]) > (globalvars.h_max / 2))
                                {
                                    h_map[xx, yy] = 0;//Der Block muss nicht geändert werden, da es nur Schattierung betrifft (höhe des Blocks).
                                    h_reset_count++;
                                }

                                if (h_low > h_map[xx, yy]) h_low = h_map[xx, yy];
                                if (h_high < h_map[xx, yy]) h_high = h_map[xx, yy];

                                //add block
                                if (newline)
                                {
                                    line = "summon falling_block ~ ~1 ~ {Time:1,BlockState:{Name:redstone_block},Passengers:[";
                                    line += "{id:falling_block,Passengers:[";
                                    line += "{id:falling_block,Time:1,BlockState:{Name:activator_rail},Passengers:[";

                                    if (firstline)
                                    {
                                        int temp_x = x - 1;
                                        line += "{id:command_block_minecart,Command:'fill ~ " + globalvars.y_start.ToString() + " ~-1 ";
                                        line += "~" + temp_x.ToString() + " " + globalvars.y_start.ToString() + " ~-1 minecraft:black_concrete'},";
                                        firstline = false;
                                    }

                                    newline = false;
                                }

                                int offset = globalvars.y_start + h_map[xx, yy];
                                string pos = "~" + xx.ToString() + " " + offset.ToString() + " ~" + yy.ToString() + " ";
                                line += "{id:command_block_minecart,Command:'setblock " + pos + globalvars.colordata[b, 4] + "'},";

                                if (line.Length >= globalvars.command_block_max)
                                {
                                    line += "{id:command_block_minecart,Command:'kill @e[distance=..1]'}]}]}]}";
                                    cmd_lines.Add(line);
                                    line = string.Empty;                                   
                                    newline = true;
                                }
                            }
                        }
                    }
                }

                progressFile++;
                worker1.ReportProgress(0);//update progress bars
            }

            if (line.Length > 0)//last line
            {
                line += "{id:command_block_minecart,Command:'kill @e[distance=..1]'}]}]}]}";
                cmd_lines.Add(line);
            }
            string[] cmd_lines_array = cmd_lines.ToArray(typeof(string)) as string[];//convert arraylist to array
            System.IO.File.WriteAllLines(@globalvars.pathSave +".txt", cmd_lines_array, Encoding.UTF8);

            if (checkBox_batch.Checked == false)
            {              
                h_high += Math.Abs(h_low) + 1;
                MessageBox.Show("Feddisch." + " Y-Resets: " + h_reset_count.ToString() + "   h max: " + h_high.ToString());               
            }

            progressFile = 0;
            worker1.ReportProgress(0);//update progress bars

            //test ausgabe in .txt
            //string[] text = new string[y]; 
            //for (int yy = 0; yy < y; yy++)
            //{
            //    for (int xx = 0; xx < x; xx++)
            //    {
            //        string abc = height_map[xx, yy].ToString();

            //        int l = 4 - abc.Length;
            //        for (int n = 0; n < l; n++)
            //        {
            //            abc = " " + abc;
            //        }

            //        text[yy] += abc+",";
            //    }
            //}
            //string path2 = @"c:\users\kevin\desktop\h_map.txt";
            //System.IO.File.WriteAllLines(path2, text, Encoding.UTF8);
        }

        public void ConvertToMapV2(int x, int y, string[,] pic)
        {
            int[,] h_map = new int[x, y];
            int previous_y = 0;
            int h_reset_count = 0;
            int h_low = 0;
            int h_high = 0;

            byte[,] c_map = new byte[x, y];
            bool[] c_used = new bool[globalvars.colordata_arraysize_x];

            for (int yy = 0; yy < y; yy++)//x of pic[,]
            {
                for (int xx = 0; xx < x; xx++)//y of pic[,]
                {
                    for (int a = 0; a < 3; a++)//shade of block in colordata[,] (nur 0-2, 3 nur bei locked map)
                    {
                        for (int b = 1; b < globalvars.colordata_arraysize_x; b++)//color of block colordata[,]
                        {
                            if (globalvars.colordata[b, a] == pic[xx, yy])
                            {
                                //h_map
                                if (yy == 0)
                                {
                                    h_map[xx, yy] = 0;
                                }
                                else
                                {
                                    previous_y = yy - 1;
                                    h_map[xx, yy] = h_map[xx, previous_y];
                                }

                                if (a == 0) h_map[xx, yy]++;
                                else if (a == 2) h_map[xx, yy]--;

                                if (Math.Abs(h_map[xx, yy]) > (globalvars.h_max / 2))
                                {
                                    h_map[xx, yy] = 0;//Der Block muss nicht geändert werden, da es nur Schattierung betrifft (höhe des Blocks).
                                    h_reset_count++;
                                }

                                if (h_low > h_map[xx, yy]) h_low = h_map[xx, yy];
                                if (h_high < h_map[xx, yy]) h_high = h_map[xx, yy];

                                //c_map
                                c_map[xx, yy] = Convert.ToByte(b);
                                c_used[b] = true;
                            }
                        }
                    }
                }
            }

            h_high += Math.Abs(h_low) + 1;
            c_used[0] = true; //minecraft:air
            
            schematic(c_map, h_map, x, y, h_high, h_low, c_used);

            if (checkBox_batch.Checked == false)
            {
                MessageBox.Show("Feddisch." + " Y-Resets: " + h_reset_count.ToString() + "   h max: " + h_high.ToString());
            }

            progressFile = 0;
            worker1.ReportProgress(0);//update progress bars
        }

        public void ConvertToMapV3(int x, int y, string[,] pic)
        {
            int mapsX = Convert.ToInt32(Math.Ceiling((double) x / 128));
            int mapsY = Convert.ToInt32(Math.Ceiling((double) y / 128));   
            int maps = mapsX * mapsY;
            byte[, ,] mapArray = new byte[128, 128, maps];

            int xx = 0;
            int yy = 0;
            int mapCount = 0;
            int addX = 0;
            int addY = 0;

            string str = string.Empty;
            bool outOfRange = false;

            progressFileMax = maps;
            worker1.ReportProgress(0);//update progress bars

            for (int mapCountY = 0; mapCountY < mapsY; mapCountY++)
            {
                for (int mapCountX = 0; mapCountX < mapsX; mapCountX++)
                {
                    for (int mapBlockCountY = 0; mapBlockCountY < 128; mapBlockCountY++)
                    {
                        for (int mapBlockCountX = 0; mapBlockCountX < 128; mapBlockCountX++)
                        {
                            //if ((mapBlockCountY > 126) | (mapBlockCountY == 0))
                            //{
                            //    MessageBox.Show(
                            //        mapBlockCountX.ToString() + ", " + mapBlockCountY.ToString() + "\n" +
                            //        xx.ToString() + ", " + yy.ToString()
                            //        );
                            //}

                            if ((xx < x) && (yy < y))
                            {
                                str = pic[xx, yy];
                                outOfRange = false;
                            }
                            else
                            {
                                str = globalvars.colordata[29, 0];
                                outOfRange = true;
                            }

                            for (int a = 0; a < 4; a++)//shade of block in colordata[,] (0-3, locked map)
                            {
                                for (int b = 1; b < globalvars.colordata_arraysize_x; b++)//color of block colordata[,]
                                {
                                    if (globalvars.colordata[b, a] == str)
                                    {
                                        int aa = 0;

                                        switch (a)
                                        {
                                            case 0: aa = 2; break;
                                            case 1: aa = 1; break;
                                            case 2: aa = 0; break;
                                            case 3: aa = 3; break;
                                            default: break;
                                        }

                                        if (outOfRange)
                                        {
                                            mapArray[mapBlockCountX, mapBlockCountY, mapCount] = 118;//ID 29 * 4 + 2
                                        }
                                        else
                                        {
                                            mapArray[mapBlockCountX, mapBlockCountY, mapCount] = Convert.ToByte(b * 4 + aa);
                                        }                                       
                                    }
                                }
                            }

                            xx++;
                        }

                        xx = addX;
                        yy++;
                    }

                    yy = addY;
                    addX += 128;
                    xx = addX;
                    mapCount++;

                    progressFile = mapCount;
                    worker1.ReportProgress(0);//update progress bars
                }

                addY += 128;
                yy = addY;
                addX = 0;
                xx = addX;
            }

            for (int i = 0; i < maps; i++)
            {
                ArrayList byteList = new ArrayList();

                byteList.Add((byte)10);//TAG_Compound ohne Name...
                byteList.Add((byte)0);
                byteList.Add((byte)0);

                byteList.AddRange(TAG_Int("DataVersion", 2230));
                byteList.AddRange(TAG_Compound("data"));
                byteList.AddRange(TAG_List_Empty("banners"));
                byteList.AddRange(TAG_List_Empty("frames"));
                byteList.AddRange(TAG_Int("dimension", 0));
                byteList.AddRange(TAG_Byte("locked", 1));
                byteList.AddRange(TAG_Byte("scale", 0));
                byteList.AddRange(TAG_Byte("trackingPosition", 1));
                byteList.AddRange(TAG_Byte("unlimitedTracking", 0));
                byteList.AddRange(TAG_Int("xCenter", 128));
                byteList.AddRange(TAG_Int("zCenter", 128));
                byteList.AddRange(TAG_Byte_Array("colors", 16384));

                byte[] BlockInfo = byteList.ToArray(typeof(byte)) as byte[];

                byte[] BlockData = new byte[16386];//+2 wegen CLOSE TAG_Compound("data") und CLOSE TAG_Compound("")
                int BlockCount = 0;

                for (int a = 0; a < 128; a++)
                {
                    for (int b = 0; b < 128; b++)
                    {
                        BlockData[BlockCount] = mapArray[b, a, i];
                        BlockCount++;
                    }
                }

                byte[] byteArray = BlockInfo.Concat(BlockData).ToArray();

                using (var memStream = new MemoryStream())
                {
                    using (var compStream = new GZipStream(memStream, CompressionMode.Compress))
                    {
                        compStream.Write(byteArray, 0, byteArray.Length);
                        compStream.Flush();
                    }

                    byte[] compressedArray = memStream.ToArray();
                    
                    File.WriteAllBytes(@globalvars.pathSaveLockedMap + "_" + globalvars.startMap.ToString() + ".dat", compressedArray);
                }

                globalvars.startMap++;
            }

            if (checkBox_batch.Checked == false)
            {
                globalvars.startMap = int.Parse(textBox_startMap.Text);
                MessageBox.Show("Maps: " + maps.ToString());
            }

            progressFile = 0;
            worker1.ReportProgress(0);//update progress bars
        }

        public void schematic(byte[,] c_map, int[,] h_map, int x, int y, int h, int h_low, bool[] c_used)
        {
            y++;
            Int16 Int16_x = Convert.ToInt16(x);
            Int16 Int16_y = Convert.ToInt16(y);
            Int16 Int16_h = Convert.ToInt16(h);
          
            byte[, ,] blocks = new byte[x, y, h];
            int blocks_total = x * y * h;
            int c_used_count = 0;
            byte c_used1 = 0;

            for (int i = 1; i < globalvars.colordata_arraysize_x; i++)
            {
                if (c_used[i])
                {
                    c_used1 = Convert.ToByte(i);
                    break;
                }
            }

            h_low = Math.Abs(h_low);

            for (int yy = 0; yy < y; yy++)
            {
                for (int xx = 0; xx < x; xx++)
                {
                    if (yy == 0)
                    {
                        blocks[xx, 0, h_low] = c_used1;
                    }
                    else
                    {
                        h_map[xx, yy - 1] += h_low;
                        blocks[xx, yy, h_map[xx, yy - 1]] = c_map[xx, yy - 1];
                    }
                }
            }
            
            ArrayList byteList = new ArrayList();

            byteList.AddRange(TAG_Compound("Schematic"));
            byteList.AddRange(TAG_Compound("Metadata"));
            byteList.AddRange(TAG_Int("WEOffsetX", 0));
            byteList.AddRange(TAG_Int("WEOffsetY", 0));
            byteList.AddRange(TAG_Int("WEOffsetZ", -1));
            byteList.Add((byte)0);//CLOSE TAG_Compound("Metadata")
            byteList.AddRange(TAG_Compound("Palette"));
            
            for (int i = 0; i < globalvars.colordata_arraysize_x; i++)
            {
                if (c_used[i])
                {
                    byteList.AddRange(TAG_Int(globalvars.colordata[i,4], i));
                    c_used_count++;
                }
            }

            byteList.Add((byte)0);//CLOSE TAG_Compound("Palette")
            byteList.AddRange(TAG_List_Empty("BlockEntities"));
            byteList.AddRange(TAG_Int("DataVersion", 2230));
            byteList.AddRange(TAG_Int("PaletteMax", c_used_count));
            byteList.AddRange(TAG_Int("Version", 2));
            byteList.AddRange(TAG_Short("Length", Int16_y));
            byteList.AddRange(TAG_Short("Width", Int16_x));
            byteList.AddRange(TAG_Short("Height", Int16_h));
            byteList.AddRange(TAG_Int_Array("Offset", new int[] { 0, 0, 0 }));
            byteList.AddRange(TAG_Byte_Array("BlockData", blocks_total));

            byte[] BlockInfo = byteList.ToArray(typeof(byte)) as byte[];

            byte[] BlockData = new byte[blocks_total + 1];
            UInt32 uint32_count = 0;

            progressFileMax = h;
            worker1.ReportProgress(0);//update progress bars

            for (int hh = 0; hh < h; hh++)
            {
                for (int yy = 0; yy < y; yy++)
                {
                    for (int xx = 0; xx < x; xx++)
                    {
                        BlockData[uint32_count] = blocks[xx, yy, hh];
                        uint32_count++;
                    }
                }

                progressFile++;
                worker1.ReportProgress(0);//update progress bars
            }

            byte[] byteArray = BlockInfo.Concat(BlockData).ToArray();           

            using (var memStream = new MemoryStream())
            {
                using (var compStream = new GZipStream(memStream, CompressionMode.Compress))
                {
                    compStream.Write(byteArray, 0, byteArray.Length);
                    compStream.Flush();
                }

                byte[] compressedArray = memStream.ToArray();
                File.WriteAllBytes(@globalvars.pathSave +".schem", compressedArray);
            }
        }

        ArrayList TAG_Byte(string name, byte input)
        {
            ArrayList byteList = new ArrayList();
            byte[] nameBytes = Encoding.ASCII.GetBytes(name);

            byteList.Add((byte)1);//add TAG ID

            byte[] l = BitConverter.GetBytes(nameBytes.Length);//add 2 byte name length
            byteList.Add(l[1]);
            byteList.Add(l[0]);

            for (int i = 0; i < nameBytes.Length; i++)//add name
            {
                byteList.Add(nameBytes[i]);
            }

            byteList.Add(input);//add input

            return byteList;
        }

        ArrayList TAG_Short(string name, Int16 input)
        {
            ArrayList byteList = new ArrayList();
            byte[] nameBytes = Encoding.ASCII.GetBytes(name);

            byteList.Add((byte)2);//add TAG ID

            byte[] l = BitConverter.GetBytes(nameBytes.Length);//add 2 byte name length
            byteList.Add(l[1]);
            byteList.Add(l[0]);

            for (int i = 0; i < nameBytes.Length; i++)//add name
            {
                byteList.Add(nameBytes[i]);
            }

            byte[] inputArray = BitConverter.GetBytes(input);//add input
            byteList.Add(inputArray[1]);
            byteList.Add(inputArray[0]);

            return byteList;
        }

        ArrayList TAG_Int(string name, int input)
        {
            ArrayList byteList = new ArrayList();
            byte[] nameBytes = Encoding.ASCII.GetBytes(name);

            byteList.Add((byte)3);//add TAG ID

            byte[] l = BitConverter.GetBytes(nameBytes.Length);//add 2 byte name length
            byteList.Add(l[1]);
            byteList.Add(l[0]);

            for (int i = 0; i < nameBytes.Length; i++)//add name
            {
                byteList.Add(nameBytes[i]);
            }

            byte[] inputArray = BitConverter.GetBytes(input);//add input
            for (int i = 3; i >= 0; i--)
            {
                byteList.Add(inputArray[i]);
            }

            return byteList;
        }

        ArrayList TAG_Byte_Array(string name, int input)
        {
            ArrayList byteList = new ArrayList();
            byte[] nameBytes = Encoding.ASCII.GetBytes(name);

            byteList.Add((byte)7);//add TAG ID

            byte[] l = BitConverter.GetBytes(nameBytes.Length);//add 2 byte name length
            byteList.Add(l[1]);
            byteList.Add(l[0]);

            for (int i = 0; i < nameBytes.Length; i++)//add name
            {
                byteList.Add(nameBytes[i]);
            }

            byte[] inputArray = BitConverter.GetBytes(input);//add input (length of bytearray)
            for (int i = 3; i >= 0; i--)
            {
                byteList.Add(inputArray[i]);
            }

            return byteList;
        }

        ArrayList TAG_List_Empty(string name)
        {
            ArrayList byteList = new ArrayList();
            byte[] nameBytes = Encoding.ASCII.GetBytes(name);

            byteList.Add((byte)9);//add TAG ID

            byte[] l = BitConverter.GetBytes(nameBytes.Length);//add 2 byte name length
            byteList.Add(l[1]);
            byteList.Add(l[0]);

            for (int i = 0; i < nameBytes.Length; i++)//add name
            {
                byteList.Add(nameBytes[i]);
            }

            byteList.Add((byte)10);//add empty TAG_Compound
            for (int i = 0; i < 4; i++)
            {
                byteList.Add((byte)0);
            }

            return byteList;
        }

        ArrayList TAG_Compound(string name)
        {
            ArrayList byteList = new ArrayList();
            byte[] nameBytes = Encoding.ASCII.GetBytes(name);

            byteList.Add((byte)10);//add TAG ID

            byte[] l = BitConverter.GetBytes(nameBytes.Length);//add 2 byte name length
            byteList.Add(l[1]);
            byteList.Add(l[0]);

            for (int i = 0; i < nameBytes.Length; i++)//add name
            {
                byteList.Add(nameBytes[i]);
            }

            return byteList;
        }

        ArrayList TAG_Int_Array(string name, int[] input)
        {
            ArrayList byteList = new ArrayList();
            byte[] nameBytes = Encoding.ASCII.GetBytes(name);

            byteList.Add((byte)11);//add TAG ID

            byte[] l = BitConverter.GetBytes(nameBytes.Length);//add 2 byte name length
            byteList.Add(l[1]);
            byteList.Add(l[0]);

            for (int i = 0; i < nameBytes.Length; i++)//add name
            {
                byteList.Add(nameBytes[i]);
            }

            byte[] inputLength = BitConverter.GetBytes(input.Length);//add input length
            for (int i = 3; i >= 0; i--)
            {
                byteList.Add(inputLength[i]);
            }

            foreach (int element in input)//add input
            {
                byte[] inputArray = BitConverter.GetBytes(element);
                for (int i = 3; i >= 0; i--)
                {
                    byteList.Add(inputArray[i]);
                }
            }

            return byteList;
        }

        public void idcountsgen()//locked map
        {
            int number = int.Parse(textBox_idcounts.Text);
            globalvars.pathSave = saveFileDialog1.FileName;

            ArrayList byteList = new ArrayList();

            byteList.Add((byte)10);//TAG_Compound ohne Name...
            byteList.Add((byte)0);
            byteList.Add((byte)0);
            byteList.AddRange(TAG_Int("DataVersion", 2230));
            byteList.AddRange(TAG_Compound("data"));
            byteList.AddRange(TAG_Int("map", number));
            byteList.Add((byte)0);//CLOSE TAG_Compound("data")
            byteList.Add((byte)0);//CLOSE TAG_Compound("")

            byte[] byteArray = byteList.ToArray(typeof(byte)) as byte[];

            using (var memStream = new MemoryStream())
            {
                using (var compStream = new GZipStream(memStream, CompressionMode.Compress))
                {
                    compStream.Write(byteArray, 0, byteArray.Length);
                    compStream.Flush();
                }

                byte[] compressedArray = memStream.ToArray();
                File.WriteAllBytes(@globalvars.pathSave + ".dat", compressedArray);
            }

            MessageBox.Show("Feddisch.");
        }
    }
}