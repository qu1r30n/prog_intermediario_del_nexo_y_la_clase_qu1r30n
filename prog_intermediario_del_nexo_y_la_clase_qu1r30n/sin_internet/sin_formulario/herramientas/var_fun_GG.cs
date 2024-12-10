﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prog_intermediario_del_nexo_y_la_clase_qu1r30n.sin_internet.sin_formularios.herramientas
{
    class var_fun_GG
    {


        static public int GG_indice_donde_comensar = 1;

        static public string[] GG_caracter_separacion = { "|", "°", "¬", "╦", "╝", "╔" };

        static public string[] GG_caracter_separacion_funciones_espesificas = { "~", "§", "¶", "╬" };

        static public string[] GG_caracter_para_confirmacion_o_error = { "╣", "╠" };

        static public string[] GG_caracter_para_transferencia_entre_archivos = { "┴", "■" };

        static public string[] GG_caracter_para_usar_como_enter_y_nuevo_mensaje = { "•", "∆" };

        static public string GG_id_programa = "INTERMEDIARIO";

        static public string GG_direccion_control_errores_try = "config\\chatbot\\errores_try\\control_errore.txt";

        
        //funciones---------------------------------------------------------------------------------------------------------

        public string[] GG_funcion_caracter_separacion(object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = null;
            if (caracter_separacion_objeto == null)
            {
                caracter_separacion = GG_caracter_separacion;
            }
            else
            {
                if (caracter_separacion_objeto is char)
                {
                    caracter_separacion = new string[] { caracter_separacion_objeto + "" };
                }
                if (caracter_separacion_objeto is string)
                {
                    if (caracter_separacion_objeto.ToString() != GG_caracter_separacion_funciones_espesificas[0])
                    {
                        caracter_separacion = caracter_separacion_objeto.ToString().Split(GG_caracter_separacion_funciones_espesificas[0][0]);
                    }
                    else
                    {
                        caracter_separacion = caracter_separacion_objeto.ToString().Split(GG_caracter_separacion_funciones_espesificas[1][0]);
                    }

                }
                if (caracter_separacion_objeto is string[])
                {
                    caracter_separacion = (string[])caracter_separacion_objeto;
                }
            }

            return caracter_separacion;

        }

        public string[] GG_funcion_caracter_separacion_funciones_especificas(object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = null;
            if (caracter_separacion_objeto == null)
            {
                caracter_separacion = GG_caracter_separacion_funciones_espesificas;
            }
            else
            {
                if (caracter_separacion_objeto is char)
                {
                    //caracter_separacion = new string[] { caracter_separacion_objeto + "" };
                    for (int i = 0; i < GG_caracter_separacion_funciones_espesificas.Length; i++)
                    {
                        if (caracter_separacion_objeto.ToString() != GG_caracter_separacion_funciones_espesificas[i])
                        {
                            caracter_separacion = caracter_separacion_objeto.ToString().Split(GG_caracter_separacion_funciones_espesificas[0][i]);
                            return caracter_separacion;
                        }
                    }

                }
                if (caracter_separacion_objeto is string)
                {
                    for (int i = 0; i < GG_caracter_separacion_funciones_espesificas.Length; i++)
                    {
                        if (caracter_separacion_objeto.ToString() != GG_caracter_separacion_funciones_espesificas[i])
                        {
                            caracter_separacion = caracter_separacion_objeto.ToString().Split(GG_caracter_separacion_funciones_espesificas[i][0]);
                            return caracter_separacion;
                        }
                    }
                }
                if (caracter_separacion_objeto is string[])
                {
                    caracter_separacion = (string[])caracter_separacion_objeto;
                }
                if (caracter_separacion_objeto is char[])
                {
                    caracter_separacion = (string[])caracter_separacion_objeto;
                }
            }

            return caracter_separacion;

        }


        //----------------------------------------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------------------------------------


        

    }
}
