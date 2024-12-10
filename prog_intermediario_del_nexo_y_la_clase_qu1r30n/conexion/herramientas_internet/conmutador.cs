using prog_intermediario_del_nexo_y_la_clase_qu1r30n.sin_internet.sin_formularios.herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using prog_intermediario_del_nexo_y_la_clase_qu1r30n.sin_internet.sin_formularios;

using System.Diagnostics.Contracts;
using System.Windows.Forms;
using System.Drawing;

namespace prog_intermediario_del_nexo_y_la_clase_qu1r30n.conexion.herramientas_internet
{
    internal class conmutador
    {

        operaciones_arreglos op_arr = new operaciones_arreglos();
        operaciones_textos op_tex = new operaciones_textos();

        Tex_base bas = new Tex_base();

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[,] G_direcciones_de_entrada_datos = var_fun_GG_dir_arch_crear.GG_direcciones_de_entrada_datos;

        

        public void conmutar_datos(string parametro)
        {

            // esplitea para saber a que programa de servidor enviara y de que cliente viene
            string[] id_programa_a_enviar = parametro.Split(G_caracter_para_transferencia_entre_archivos[0][0]);
            string[] res_espliteada = id_programa_a_enviar[1].Split(G_caracter_para_transferencia_entre_archivos[1][0]);

            string prog_a_enviar = id_programa_a_enviar[0];
            string prog_del_que_lo_envia = res_espliteada[0];

            bool encontro_el_ide = false;
            bool tiene_permiso = false;

            
            
            for (int i = 0; i < G_direcciones_de_entrada_datos.GetLength(0); i++)
            {
                //encontro id programa a enviar
                if (prog_a_enviar == G_direcciones_de_entrada_datos[i, 0])
                {
                    encontro_el_ide = true;
                    string dir_al_que_va_enviar = G_direcciones_de_entrada_datos[i, 1];
                    string[] ids_que_tienen_permiso = G_direcciones_de_entrada_datos[i, 2].Split(G_caracter_separacion_funciones_espesificas[0][0]);
                    for (int j = 0; j < ids_que_tienen_permiso.Length; j++)
                    {
                        //tiene permiso el id del programa que lo envia
                        if (ids_que_tienen_permiso[j] == prog_del_que_lo_envia) 
                        {
                            tiene_permiso = true;
                            bas.Agregar(dir_al_que_va_enviar, parametro);
                            break;
                        }
                    }
                    break;
                }
                
            }



            if (encontro_el_ide == true && tiene_permiso == false)
            {
                error_intermediario_mandar_mensaje_al_que_envio(prog_del_que_lo_envia, "0" + G_caracter_para_confirmacion_o_error[0] + "NO TIENE PERMISO");
            }
            else if (encontro_el_ide == false)
            {
                error_intermediario_mandar_mensaje_al_que_envio(prog_del_que_lo_envia, "0" + G_caracter_para_confirmacion_o_error[0] + "NO SE ENCONTRO ID DEL PROGRAMA");
            }
            

            
        }

        private void error_intermediario_mandar_mensaje_al_que_envio(string prog_del_que_lo_envia, string mensaje)
        {
            string direccion_del_que_lo_envia = null;
            for (int i = 0; i < G_direcciones_de_entrada_datos.GetLength(0); i++)
            {
                if (prog_del_que_lo_envia == G_direcciones_de_entrada_datos[i, 0])
                {
                    direccion_del_que_lo_envia = G_direcciones_de_entrada_datos[i, 0];
                }
            }
            if (direccion_del_que_lo_envia != null)
            {
                conexiones con = new conexiones();
                con.datos_a_enviar(direccion_del_que_lo_envia, mensaje, prog_del_que_lo_envia);
            }
            
        }
        //fin procesos-------------------------------------------------------------------------------------------
    }
}