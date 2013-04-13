using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cuboNumerico.Model
{
    public class No
    {
        private CuboNumerico estado;
        private No pai;
        private int custo;
        private int movimentos; 

        public No(CuboNumerico estado, No pai, int custo, int movimentos)
        {
            this.estado = estado;
            this.pai = pai;
            this.custo = custo;
            this.movimentos = movimentos;
        }

        public CuboNumerico Estado
        {
            get { return this.estado; }
        }

        public No Pai
        {
            get { return this.pai; }
        }

        public int Custo
        {
            get { return this.custo; }
        }
        public int Movimentos
        {
            get { return this.movimentos; }
        }

        public Boolean Equals(CuboNumerico inOutroCubo)
        {
            return estado.Equals(inOutroCubo);
        }

        public Boolean verificaCiclo(CuboNumerico inOutroCubo)
        {
            No aux = this;

            while (aux != null)
            {
                if (aux.Equals(inOutroCubo))
                    return true;
                aux = aux.Pai;
            }
            return false;
        }

        public Boolean verificaCicloGanaciosa(CuboNumerico inOutroCubo, int inOutroCusto)
        {
            No aux = this;
            int aumentoDoCusto = 0;

            while (aux != null)
            {
                if (inOutroCusto > aux.Custo)
                    aumentoDoCusto++;

                if (aux.Equals(inOutroCubo) || aumentoDoCusto >= 3)
                    return true;        
        
                aux = aux.Pai;
            }
            return false;
        }

        public List<No> sucessores(Boolean verificaCiclo)
        {
            List<No> listaSucessores = new List<No>();
            No aux;
            
            try
            {
                // Movimento Vertical para cima (tomando face1 como principal)
                aux = new No(this.estado.movimentoVertical(0, 1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                aux = new No(this.estado.movimentoVertical(1, 1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                aux = new No(this.estado.movimentoVertical(2, 1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                // Movimento Vertical para baixo (tomando face1 como principal)
                aux = new No(this.estado.movimentoVertical(0, -1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                aux = new No(this.estado.movimentoVertical(1, -1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                aux = new No(this.estado.movimentoVertical(2, -1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);
                
                // Movimento Horizontal para direita (tomando face1 como principal)
                aux = new No(this.estado.movimentoHorizontal(0, 1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                aux = new No(this.estado.movimentoHorizontal(1, 1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                aux = new No(this.estado.movimentoHorizontal(2, 1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                // Movimento Horizontal para esquerda (tomando face1 como principal)
                aux = new No(this.estado.movimentoHorizontal(0, -1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                aux = new No(this.estado.movimentoHorizontal(1, -1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                aux = new No(this.estado.movimentoHorizontal(2, -1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);
                
                // Movimentto Lateral para direita (tomando face2 como principal)
                aux = new No(this.estado.movimentoLateral(0, 1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                aux = new No(this.estado.movimentoLateral(1, 1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                aux = new No(this.estado.movimentoLateral(2, 1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                // Movimentto Lateral para esquerda (tomando face2 como principal)
                aux = new No(this.estado.movimentoLateral(0, -1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                aux = new No(this.estado.movimentoLateral(1, -1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                aux = new No(this.estado.movimentoLateral(2, -1), this, this.custo + 1, this.custo + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);
                
                return listaSucessores;
            }
            catch (Exception ex)
            {
                throw new Exception("sucessores: " + ex.Message);
            }

        }

        public List<No> sucessoresAEstrela(CuboNumerico inCuboObjetivo ,Boolean verificaCiclo)
        {
            List<No> listaSucessores = new List<No>();
            No aux;
            CuboNumerico cuboAux;
            

            try
            {
                // Movimento Vertical para cima (tomando face1 como principal)
                cuboAux = this.estado.movimentoVertical(0, 1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                cuboAux = this.estado.movimentoVertical(1, 1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                cuboAux =  this.estado.movimentoVertical(2, 1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                // Movimento Vertical para baixo (tomando face1 como principal)
                cuboAux = this.estado.movimentoVertical(0, -1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                cuboAux = this.estado.movimentoVertical(1, -1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                cuboAux = this.estado.movimentoVertical(2, -1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                // Movimento Horizontal para direita (tomando face1 como principal)
                cuboAux = this.estado.movimentoHorizontal(0, 1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                cuboAux = this.estado.movimentoHorizontal(1, 1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                cuboAux = this.estado.movimentoHorizontal(2, 1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                // Movimento Horizontal para esquerda (tomando face1 como principal)
                cuboAux = this.estado.movimentoHorizontal(0, -1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                cuboAux = this.estado.movimentoHorizontal(1, -1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                cuboAux = this.estado.movimentoHorizontal(2, -1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                // Movimentto Lateral para direita (tomando face2 como principal)
                cuboAux = this.estado.movimentoLateral(0, 1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                cuboAux = this.estado.movimentoLateral(1, 1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                cuboAux = this.estado.movimentoLateral(2, 1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                // Movimentto Lateral para esquerda (tomando face2 como principal)
                cuboAux = this.estado.movimentoLateral(0, -1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                cuboAux = this.estado.movimentoLateral(1, -1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);

                cuboAux = this.estado.movimentoLateral(2, -1);
                aux = new No(cuboAux, this, cuboAux.pecasForaDoLugar(inCuboObjetivo) + this.movimentos + 1, this.movimentos + 1);
                if (!verificaCiclo || !this.verificaCiclo(aux.Estado))
                    listaSucessores.Add(aux);
                                
                return listaSucessores;
            }
            catch (Exception ex)
            {
                throw new Exception("sucessoresGananciosa: " + ex.Message);
            }

        }

    }
}
