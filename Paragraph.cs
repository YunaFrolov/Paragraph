// Yuna Frolov
// Daniel Netzer

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW4_cs
{
    class Paragraph
    {
        string paragraph;
        string copyPar;
        int space;
        int max;
        int ident = 0;
  
        public Paragraph(string text){
            SetText(text);
            copyPar = text;
        }

        public void SetText(string text){
            paragraph = text;
        }

        public string breakPargraph(){
            string[] words = copyPar.Split(' ');

            for (int i = 0; i < words.Length; i++){
                if (words[i].Length > 20)
                    return "Can't display";
            }

            int a = countWords();
            string add=""+counIdent();
            string reAdd = "";
            for(int i=0;i<a;i++){
                
                int aL = add.Length;
                if (aL+words[i].Length <= 20) {
                    add=add+words[i]+" ";
                }

                if (aL + words[i].Length > 20 ) {
                    if (space == 0)
                        reAdd = reAdd + add+"\n";
                    if(space==1)
                        reAdd = reAdd + add + "\n\n";
                    i--;
                    add = "";
                }
                if (i == a - 1){
                    if (space == 0)
                            reAdd = reAdd + add + "\n";
                    if (space == 1)
                            reAdd = reAdd + add + "";
                    }
                }  
            
            return reAdd;
            }

        public void GetParameters(out int iden,out int space,out int w) {
            iden = ident;
            space = this.space;
            w = max;
        }

        public void SetParameters( int iden, int space, int maxPass) {
            this.ident=iden;
            this.max = maxPass;
            this.space = space;
            
        }

        public int countWords(){
            string[] stringSeparators = new string[] { " " };
            string[] words = paragraph.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            return words.Length;
            }

        public string counIdent(){
            string re = "";
            int i = 0;
            while (i < ident)
            {
                re = re + " ";
                i = i + 1;
            }
            return re;
        } 

        public override string ToString(){
             counIdent();

             return breakPargraph(); ;
        }

        static void Main(string[] args) {
            Paragraph paragraph = new Paragraph("Many many many words. this is a long paragraph: very very long!!");
            
            paragraph.SetParameters(3, 1, 20);
            Console.WriteLine(paragraph.ToString());
            Console.WriteLine("number of word in paragraph is:{0}", paragraph.countWords());

            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}

