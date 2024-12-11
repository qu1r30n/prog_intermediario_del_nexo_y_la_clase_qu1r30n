using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prog_intermediario_del_nexo_y_la_clase_qu1r30n.sin_internet.sin_formularios;
using prog_intermediario_del_nexo_y_la_clase_qu1r30n.sin_internet.sin_formularios.herramientas;

namespace prog_intermediario_del_nexo_y_la_clase_qu1r30n
{

    internal class iniciar_archivos
    {

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        public string[,] G_dir_y_datos_de_arch_transferencia = var_fun_GG_dir_arch_crear.GG_direcciones_de_entrada_datos;

        Tex_base bas = new Tex_base();
        public void iniciar()
        {

            for (int j = 0; j < G_dir_y_datos_de_arch_transferencia.GetLength(0); j++)
            {
                //{"id_prog","archivo_de_entrada","ids_programas_que_tienen_permiso","archivo_de_entrada_al_intermediario ","archivo_de_bandera"}
                string id_prog = G_dir_y_datos_de_arch_transferencia[j, 0];
                string archivo_de_entrada = G_dir_y_datos_de_arch_transferencia[j, 1];
                string ids_programas_que_tienen_permiso = G_dir_y_datos_de_arch_transferencia[j, 2];
                string archivo_de_entrada_al_intermediario = G_dir_y_datos_de_arch_transferencia[j, 3];
                string archivo_de_bandera = G_dir_y_datos_de_arch_transferencia[j, 4];

                bas.Crear_archivo_y_directorio(archivo_de_entrada, "SIN_INFO");
                bas.Crear_archivo_y_directorio(archivo_de_entrada_al_intermediario, "SIN_INFO");
                bas.Crear_archivo_y_directorio(archivo_de_bandera, var_fun_GG.GG_id_programa, new string[] { var_fun_GG.GG_id_programa });

                string[] inf_arc = bas.Leer(archivo_de_bandera);

                if (inf_arc == null)
                {
                    bas.Agregar(archivo_de_bandera, var_fun_GG.GG_id_programa + "\n" + var_fun_GG.GG_id_programa);
                }
                else if (inf_arc.Length == 1 && inf_arc[0] == "")
                {
                    bas.Agregar(archivo_de_bandera, var_fun_GG.GG_id_programa + "\n" + var_fun_GG.GG_id_programa);
                }
                else if (inf_arc.Length == 0)
                {
                    bas.Agregar(archivo_de_bandera, var_fun_GG.GG_id_programa + "\n" + var_fun_GG.GG_id_programa);
                }
                else
                {
                    bas.Agregar_sino_existe(archivo_de_bandera, 0, var_fun_GG.GG_id_programa, var_fun_GG.GG_id_programa);
                }
            }
        }






        //fin clase-----------------------------------------------------------------------------
    }
}