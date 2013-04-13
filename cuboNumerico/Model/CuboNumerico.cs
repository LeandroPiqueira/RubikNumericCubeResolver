using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cuboNumerico.Model
{  
    public class CuboNumerico
    {
        private int[,] face1;
        private int[,] face2;
        private int[,] face3;
        private int[,] face4;
        private int[,] face5;
        private int[,] face6;

        private string movimentoOrigem;
        private int faceReferenciaOrigem;
        private int linhaColunaOrigem;

        public CuboNumerico(int in111, int in112, int in113, 
                            int in121, int in122, int in123,
                            int in131, int in132, int in133,
                            int in211, int in212, int in213, 
                            int in221, int in222, int in223,
                            int in231, int in232, int in233,
                            int in311, int in312, int in313, 
                            int in321, int in322, int in323,
                            int in331, int in332, int in333,
                            int in411, int in412, int in413, 
                            int in421, int in422, int in423,
                            int in431, int in432, int in433,
                            int in511, int in512, int in513, 
                            int in521, int in522, int in523,
                            int in531, int in532, int in533,
                            int in611, int in612, int in613, 
                            int in621, int in622, int in623,
                            int in631, int in632, int in633)
        {            
            this.face1 = new int[,] { { in111, in112, in113 }, { in121, in122, in123 }, { in131, in132, in133 } };
            this.face2 = new int[,] { { in211, in212, in213 }, { in221, in222, in223 }, { in231, in232, in233 } };
            this.face3 = new int[,] { { in311, in312, in313 }, { in321, in322, in323 }, { in331, in332, in333 } };
            this.face4 = new int[,] { { in411, in412, in413 }, { in421, in422, in423 }, { in431, in432, in433 } };
            this.face5 = new int[,] { { in511, in512, in513 }, { in521, in522, in523 }, { in531, in532, in533 } };
            this.face6 = new int[,] { { in611, in612, in613 }, { in621, in622, in623 }, { in631, in632, in633 } };
            // * * * 
            this.movimentoOrigem = "Inicial";
            this.faceReferenciaOrigem = 0;
            this.linhaColunaOrigem = 0;
        }

        public CuboNumerico(string movOrig,  int faceRefOrig, int colunaLinha, int [,] face1, int[,] face2, int[,] face3, int[,] face4, int[,] face5, int[,] face6)
        {
            this.face1 = face1;
            this.face2 = face2;
            this.face3 = face3;
            this.face4 = face4;
            this.face5 = face5;
            this.face6 = face6;
            // * * * 
            this.movimentoOrigem = movOrig;
            this.faceReferenciaOrigem = faceRefOrig;
            this.linhaColunaOrigem = colunaLinha;
        }

        public ArrayList faces()
        {
            ArrayList listaFaces = new ArrayList();

            listaFaces.Add(this.face1);
            listaFaces.Add(this.face2);
            listaFaces.Add(this.face3);
            listaFaces.Add(this.face4);
            listaFaces.Add(this.face5);
            listaFaces.Add(this.face6);

            return listaFaces;
        }

        public int pecasNoMesmoLugar(CuboNumerico inOutroCubo)
        {
            int numPecasNoMesmoLugar = 0;

            ArrayList inOutraListaFaces = inOutroCubo.faces();
            ArrayList localListaFaces = this.faces();

            for (int i = 0; i < inOutraListaFaces.Count; i++)
            {
                int[,] inFace = (int[,]) inOutraListaFaces[i];
                int[,] localFace = (int[,]) localListaFaces[i];

                for (int j = 0; j < (inFace.Length / 3); j++)
                {
                    for (int k = 0; k < (inFace.Length / 3); k++)
                    {
                        if (inFace[j, k] == localFace[j, k])
                            numPecasNoMesmoLugar++;
                    }
                }
            }
            return numPecasNoMesmoLugar;
        }

        public int pecasForaDoLugar(CuboNumerico inOutroCubo)
        {
            return (54 - pecasNoMesmoLugar(inOutroCubo));
        }

        public static int pecasForaDoLugar(CuboNumerico cubo1, CuboNumerico cubo2)
        {
            int numPecasNoMesmoLugar = 0;

            ArrayList inOutraListaFaces = cubo1.faces();
            ArrayList localListaFaces = cubo2.faces();

            for (int i = 0; i < inOutraListaFaces.Count; i++)
            {
                int[,] inFace = (int[,])inOutraListaFaces[i];
                int[,] localFace = (int[,])localListaFaces[i];

                for (int j = 0; j < (inFace.Length / 3); j++)
                {
                    for (int k = 0; k < (inFace.Length / 3); k++)
                    {
                        if (inFace[j, k] == localFace[j, k])
                            numPecasNoMesmoLugar++;
                    }
                }
            }
            return (54 - numPecasNoMesmoLugar);
        }

        public Boolean Equals(CuboNumerico inOutroCubo)
        {
            return pecasNoMesmoLugar(inOutroCubo).Equals(54);
        }
                        
        public CuboNumerico movimentoVertical(int coluna, int direcao)
        {
            string strMovimento = "Vertical";

            int[,] faceNova1 = new int[3,3];
            int[,] faceNova2 = new int[3, 3];
            int[,] faceNova3 = new int[3, 3];
            int[,] faceNova4 = new int[3, 3];
            int[,] faceNova5 = new int[3, 3];
            int[,] faceNova6 = new int[3, 3];
       
            Array.Copy(this.face1, faceNova1, face1.Length);
            Array.Copy(this.face2, faceNova2, face2.Length);
            Array.Copy(this.face3, faceNova3, face3.Length);
            Array.Copy(this.face4, faceNova4, face4.Length);
            Array.Copy(this.face5, faceNova5, face5.Length);
            Array.Copy(this.face6, faceNova6, face6.Length);

            if (direcao > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    faceNova1[i, coluna] = this.face2[i, coluna];
                    faceNova2[i, coluna] = this.face3[i, coluna];
                    faceNova3[i, coluna] = this.face4[i, coluna];
                    faceNova4[i, coluna] = this.face1[i, coluna];
                }
                strMovimento += " para Cima";
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    faceNova1[i, coluna] = this.face4[i, coluna];
                    faceNova2[i, coluna] = this.face1[i, coluna];
                    faceNova3[i, coluna] = this.face2[i, coluna];
                    faceNova4[i, coluna] = this.face3[i, coluna];
                }
                strMovimento += " para Baixo";
            }

            if (coluna.Equals(0))
            {
                faceNova5 = giraAdjacente(this.face5, direcao);
            }
            else if (coluna.Equals(2))
            {
                faceNova6 = giraAdjacente(this.face6, (-1) * direcao);
            }

            return new CuboNumerico(strMovimento, 1,coluna+1, faceNova1, faceNova2, faceNova3, faceNova4, faceNova5, faceNova6);
        }


        public CuboNumerico movimentoHorizontal(int linha, int direcao)
        {
            string strMovimento = "Horizontal";

            int[,] faceNova1 = new int[3, 3];
            int[,] faceNova2 = new int[3, 3];
            int[,] faceNova3 = new int[3, 3];
            int[,] faceNova4 = new int[3, 3];
            int[,] faceNova5 = new int[3, 3];
            int[,] faceNova6 = new int[3, 3];

            Array.Copy(this.face1, faceNova1, face1.Length);
            Array.Copy(this.face2, faceNova2, face2.Length);
            Array.Copy(this.face3, faceNova3, face3.Length);
            Array.Copy(this.face4, faceNova4, face4.Length);
            Array.Copy(this.face5, faceNova5, face5.Length);
            Array.Copy(this.face6, faceNova6, face6.Length);

            if (direcao > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    faceNova1[linha, i] = this.face5[(2 - i), linha];
                    faceNova5[(2 - i), linha] = this.face3[(2 - linha), (2 - i)];
                    faceNova3[(2 - linha), (2 - i)] = this.face6[i, (2 - linha)];
                    faceNova6[i, (2 - linha)] = this.face1[linha, i];
                }
                strMovimento += " para Direita";
            }
            else
            { 
                for (int i = 0; i < 3; i++)
                {
                    faceNova1[linha, i] =  face6[i, (2 - linha)];
                    faceNova5[(2 - i), linha] = face1[linha, i];
                    faceNova3[(2 - linha), (2 - i)] = face5[(2 - i), linha];
                    faceNova6[i, (2 - linha)] = face3[(2 - linha), (2 - i)];
                }
                strMovimento += " para Esquerda";
            }

            if (linha.Equals(0))
            {
                faceNova4 = giraAdjacente(this.face4, direcao);
            }
            else if (linha.Equals(2))
            {
                faceNova2 = giraAdjacente(this.face2, (-1) * direcao);
            }

            return new CuboNumerico(strMovimento,1, linha+1, faceNova1, faceNova2, faceNova3, faceNova4, faceNova5, faceNova6);
        }


        public CuboNumerico movimentoLateral(int linha, int direcao)
        {
            string strMovimento = "Horizontal";
            
            int[,] faceNova1 = new int[3, 3];
            int[,] faceNova2 = new int[3, 3];
            int[,] faceNova3 = new int[3, 3];
            int[,] faceNova4 = new int[3, 3];
            int[,] faceNova5 = new int[3, 3];
            int[,] faceNova6 = new int[3, 3];

            Array.Copy(this.face1, faceNova1, face1.Length);
            Array.Copy(this.face2, faceNova2, face2.Length);
            Array.Copy(this.face3, faceNova3, face3.Length);
            Array.Copy(this.face4, faceNova4, face4.Length);
            Array.Copy(this.face5, faceNova5, face5.Length);
            Array.Copy(this.face6, faceNova6, face6.Length);

            if (direcao > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    faceNova2[linha, i] = this.face5[linha, i];
                    faceNova6[linha, i] = this.face2[linha, i];
                    faceNova4[(2 - linha), (2 - i)] = this.face6[linha, i];
                    faceNova5[linha, i] = this.face4[(2 - linha), (2 - i)];
                }
                strMovimento += " para Direita";
            }
            else 
            {
                for (int i = 0; i < 3; i++)
                {
                    faceNova2[linha, i] = this.face6[linha, i];
                    faceNova6[linha, i] = this.face4[(2 - linha), (2 - i)];
                    faceNova4[(2 - linha), (2 - i)] = this.face5[linha, i];
                    faceNova5[linha, i] = this.face2[linha, i];   
                }
                strMovimento += " para Esquerda";
            }

            if (linha.Equals(0))
            {
                faceNova1 = giraAdjacente(this.face1, direcao);   
            }
            else if (linha.Equals(2))
            {
                faceNova3 = giraAdjacente(this.face3, (-1)*direcao);
            }

            return new CuboNumerico(strMovimento,2 ,linha+1, faceNova1, faceNova2, faceNova3, faceNova4, faceNova5, faceNova6);
        }


        private int[,] giraAdjacente(int[,] face, int direcao)
        {
            int[,] faceNova = new int[3,3];

            Array.Copy(face, faceNova, face.Length);

            if (direcao < 0)
            {
                for (int i = 0; i < (face.Length / 3); i++)
                {
                    for (int j = 0; j < (face.Length / 3); j++)
                    {
                        faceNova[i, j] = face[(2 - j), i];
                    }
                }
            }
            else 
            {
                for (int i = 0; i < (face.Length / 3); i++)
                {
                    for (int j = 0; j < (face.Length / 3); j++)
                    {
                        faceNova[i, j] = face[j,  (2 - i)];
                    }
                }
            }
            return faceNova;
        }

        public override string ToString() 
        {
            string strOut = "";

            strOut += Environment.NewLine;
            strOut += "==---------==---------==---------==---------==---------==";
            strOut += Environment.NewLine;

            strOut += this.movimentoOrigem + Environment.NewLine + 
                "Face Referência: " + this.faceReferenciaOrigem;

            if (this.movimentoOrigem.Contains("Vertical")) 
                strOut += Environment.NewLine + "Coluna: " + this.linhaColunaOrigem;
            else if (this.movimentoOrigem.Contains("Horizontal"))
                strOut += Environment.NewLine + "Linha: " + this.linhaColunaOrigem;

            strOut += Environment.NewLine;

            // * * * 
            // Face 1
            int[,] face = this.face1;

            for (int i = 0; i < (face.Length / 3); i++)
            {

                strOut += Environment.NewLine;
                strOut += " ";

                for (int j = 0; j < (face.Length / 3); j++)
                {
                    strOut += Convert.ToString(face[i, j]);
                }
            }

            strOut += Environment.NewLine;

            // * * *
            //Faces 5 - 2 - 6
            face = this.face5;
            int[,] faceAux = this.face2;
            int[,] faceAuxAux = this.face6;

            for (int i = 0; i < (face.Length / 3); i++)
            {

                strOut += Environment.NewLine;

                for (int j = 0; j < (face.Length / 3); j++)
                {
                    strOut += Convert.ToString(face[i, j]);
                }
                strOut += "  ";
                for (int j = 0; j < (face.Length / 3); j++)
                {
                    strOut += Convert.ToString(faceAux[i, j]);
                }
                strOut += "  ";
                for (int j = 0; j < (face.Length / 3); j++)
                {
                    strOut += Convert.ToString(faceAuxAux[i, j]);
                }
            }

            strOut += Environment.NewLine;

            // * * *
            //Face 3 
            face = this.face3;

            for (int i = 0; i < (face.Length / 3); i++)
            {

                strOut += Environment.NewLine;
                strOut += " ";

                for (int j = 0; j < (face.Length / 3); j++)
                {
                    strOut += Convert.ToString(face[i, j]);
                }
            }

            strOut += Environment.NewLine;

            // * * *
            //Face 4 
            face = this.face4;

            for (int i = 0; i < (face.Length / 3); i++)
            {

                strOut += Environment.NewLine;
                strOut += " ";

                for (int j = 0; j < (face.Length / 3); j++)
                {
                    strOut += Convert.ToString(face[i, j]);
                }
            }
            return strOut;
        }

    }
}
