using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CreateBinary
{
    class Program
    {
        static void CreateBinary()
        {
            int N = 10; // define el tamaño del archivo
            String[] tipos=new string[N]; //guarda el tipo de dato.
            
            int tam = 0;
            String tip=null; // guarda el tipo de dato.

            //Console.WriteLine("Name your binary file: ");
            //string fileName = Console.ReadLine();
            string fileName = "prueba.bin";
            //FileStream fs = new FileStream(fileName + ".bin", FileMode.Create);
            //FileStream fich;
            FileStream fich_aux;
            //fich = File.Create(fileName);
            fich_aux = File.Create("temp.txt");
            //BinaryWriter bw = new BinaryWriter(fs);
            StreamWriter sw = new StreamWriter(fileName);
            //BinaryWriter bw = new BinaryWriter(fich);
            BinaryWriter bw_aux = new BinaryWriter(fich_aux);
            //Bucle para guardar las diferentes iteracciones.
            int i = -1;
            
            while (tip!="exit" || tip != "Exit" && i<N) {
                
                Console.WriteLine("Enter de format (String, Double, Int, Float, ...). Write exit to stop.");
                tip = Console.ReadLine();
                    if (tip.Equals("exit") || tip.Equals("Exit"))
                    {
                        break;
                    }
                //incrementa las posiciones de los datos una vez que sabemos que se desean seguir introduciendo datos.
                i++;
                //tipos[i] = tip;
                string tipo = StringToBinary(tip);
                sw.WriteLine(tipo);
                //bw.Write(tipo);
                
                switch (tip)
                {
                    case "int":
                        Console.WriteLine("Enter the INT Number: ");
                        int t = Console.Read();
                        int num = Convert.ToSByte(t);
                        sw.WriteLine(StringToBinary("32"));
                        sw.WriteLine(StringToBinary(t.ToString()));
                        //bw.Write(StringToBinary("32"));
                        //bw.Write(num);
                        break;

                    case "string":
                        int tam_cad = 0;
                        Console.WriteLine("Enter the String: ");
                        string cadena = Console.ReadLine();
                       
                        foreach (char L in cadena.ToCharArray())
                        {
                            bw_aux.Write(Convert.ToString(L, 2).PadLeft(8, '0'));
                            tam_cad++;
                        }
                        sw.WriteLine(StringToBinary(tam_cad.ToString()));
                        sw.WriteLine(StringToBinary(cadena));
                        //bw.Write(tam_cad);
                        //bw.Write(StringToBinary(cadena));
                        break;

                    case "double":
                        //Console.WriteLine("Enter the double Number: ");
                        //double d = Convert.ToSByte(Console.ReadLine());
                        double d = 112.115;
                        sw.WriteLine(StringToBinary("64"));
                        sw.WriteLine(StringToBinary(d.ToString()));

                        //bw.Write(StringToBinary("64"));
                        //bw.Write(112.115);                       
                        break;

                    case "float":
                        Console.WriteLine("Enter the float Number: ");
                        //float f= Convert.ToSByte(Console.ReadLine());                       
                        float f = 95.32F;
                        sw.WriteLine(StringToBinary("32"));
                        sw.WriteLine(StringToBinary(f.ToString()));

                        //bw.Write(StringToBinary("32"));
                        //bw.Write(95.32F);                       
                        break;
                }
            }
            sw.Close();
            bw_aux.Close();
            fich_aux.Close();
        }
        

        static void ReadBinary()
        { 
            Console.WriteLine("Which file do you want to preview: ");
            string fileName = Console.ReadLine();
            //FileStream fs = new FileStream(fileName, FileMode.Open);
            StreamReader sr = new StreamReader(fileName);
            //BinaryReader br = new BinaryReader(fs);
            //string read = br.ReadString();
            //Console.WriteLine(BinaryToString(read));
            int n = 0;
            while (n < 7) {
                Console.WriteLine(BinaryToString(sr.ReadLine()));
                n++;
            }
            
    
            sr.Close();
           // fs.Close();
           // fs.Close();
        }

        public static string StringToBinary(string texto)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in texto.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }


        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        

        static void Main(string[] args)
        {
         /*   //making some tries.
            Console.WriteLine("Enter the word:");
            string word=Console.ReadLine();
            Console.WriteLine(StringToBinary(word));

            Console.WriteLine("Enter the word:");
            string word2 = Console.ReadLine();
            Console.WriteLine(StringToBinary(word2));
            */
            CreateBinary();
            ReadBinary();
            Console.ReadKey();
        }
    }
}

