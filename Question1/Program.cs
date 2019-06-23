using System;

namespace Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            FixMultiplication fx = new FixMultiplication();
            if(args.Length > 0){
                int result = fx.FindDigit(args[0]);
                Console.WriteLine($"Returns: {result}");
            }else{
                Console.WriteLine("Please Enter an Argument");
            }
        }
    }

    class FixMultiplication {
        public int FindDigit(String s){
            int r = -1;
            int a=0, b=0, c=0;
            String A="", B="", C="";
            int strt = s.IndexOf("*");
            int lst = s.IndexOf("=");
            
            //Distributing the no. in A B C
            for(int i=s.Length-1; i>=0; i--){
                if(s[i].Equals('=')){
                    C = s.Substring(i+1);
                }
                if(s[i].Equals('*')){
                    B = s.Substring(i+1, lst-strt-1);
                }
            }
            A = s.Substring(0, strt);

            //Converting A B C into no.
            if(A.IndexOf('?')<0){
                a = Int32.Parse(A);
            }
            if(B.IndexOf('?')<0){
                b = Int32.Parse(B);
            }
            if(C.IndexOf('?')<0){
                c = Int32.Parse(C);
            }

            //Checking for missing digit
            if(C.IndexOf('?')>=0){
                int ans = a*b;
                String str = ans.ToString();
                int pos = C.IndexOf('?');
                char res = str[pos];
                r = res - '0';

                if(C.IndexOf('?')==0){
                    if(str.Equals(C.Substring(1))){
                        r=-1;
                    }
                }
            }
            if(A.IndexOf('?')>=0){
                if(b != 0){
                    int ans = c/b;
                    String str = ans.ToString();
                    int pos = A.IndexOf('?');
                    char res = str[pos];
                    r = res - '0';

                    if(A.IndexOf('?')==0){
                        if(str.Equals(A.Substring(1))){
                        r=-1;
                        }
                    }
                    if(A.IndexOf('?')==A.Length-1){
                        if(str.Equals(A.Substring(0, A.Length-2))){
                        r=-1;
                        }else {
                            String strA = A.Substring(0,A.Length-1);
                            int Aa = Int32.Parse(strA);
                            for(int x=0; x<10; x++){
                                if(((Aa)*10+x)*b==c){
                                    r = x;
                                    break;
                                }
                                if((Aa*10+x)*b!=c){
                                    r=-1;
                                }
                            }
                        }
                    }
                }else{
                    r=-1;
                }
            }
            if(B.IndexOf('?')>=0){
                if(a != 0){
                    int ans = c/a;
                    String str = ans.ToString();
                    int pos = B.IndexOf('?');
                    char res = str[pos];
                    r = res - '0';

                    if(B.IndexOf('?')==0){
                        if(str.Equals(B.Substring(1))){
                        r=-1;
                        }
                    }
                    if(B.IndexOf('?')==B.Length-1){
                        if(str.Equals(B.Substring(0, B.Length-2))){
                        r=-1;
                        }else {
                            String strB = B.Substring(0,B.Length-1);
                            int Bb = Int32.Parse(strB);
                            for(int x=0; x<10; x++){
                                if(((Bb)*10+x)*a==c){
                                    r = x;
                                    break;
                                }
                                if((Bb*10+x)*a!=c){
                                    r=-1;
                                }
                            }
                        }
                    }
                }else{
                    r=-1;
                }
            }


            return r;
        }
    }
}
