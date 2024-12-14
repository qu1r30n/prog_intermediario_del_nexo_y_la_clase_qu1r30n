using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prog_intermediario_del_nexo_y_la_clase_qu1r30n.sin_internet.sin_formularios;
using prog_intermediario_del_nexo_y_la_clase_qu1r30n.sin_internet.sin_formularios.herramientas;

namespace prog_intermediario_del_nexo_y_la_clase_qu1r30n.conexion.herramientas_internet
{
    internal class conexiones
    {

        


        public string[,] G_dir_y_datos_de_arch_transferencia = var_fun_GG_dir_arch_crear.GG_direcciones_de_entrada_datos;



        operaciones_arreglos op_arr = new operaciones_arreglos();
        operaciones_textos op_tex = new operaciones_textos();

        Tex_base bas = new Tex_base();

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        
        
        


        public void datos_a_enviar(string dir_archivo,string info, string programa_enviar = "NEXOPORTALARCANO")
        {
            //E_2_5_ia
            //segun 3_6 es para peticiones o talves otro programa como otra conexion ws pero creo que es exesivo

            string info_a_enviar = programa_enviar + G_caracter_para_transferencia_entre_archivos[0] + var_fun_GG.GG_id_programa + G_caracter_para_transferencia_entre_archivos[1] + info;


            bas.Agregar(dir_archivo, info_a_enviar);

        }

        public void datos_recibidos_a_procesar_y_borrar()
        {
            // S_1_4_ia

            for (int j_____ = 0; j_____ < G_dir_y_datos_de_arch_transferencia.GetLength(0); j_____++)
            {
                //{"id_prog","archivo_de_entrada","ids_programas_que_tienen_permiso","archivo_de_entrada_al_intermediario ","archivo_de_bandera"}
                string id_prog = G_dir_y_datos_de_arch_transferencia[j_____, 0];
                string archivo_de_entrada = G_dir_y_datos_de_arch_transferencia[j_____, 1];
                string ids_programas_que_tienen_permiso = G_dir_y_datos_de_arch_transferencia[j_____, 2];
                
                string archivo_de_entrada_al_intermediario = G_dir_y_datos_de_arch_transferencia[j_____, 3];
                string archivo_de_bandera = G_dir_y_datos_de_arch_transferencia[j_____, 4];

                // Leer datos de usuarios desde un archivo
                string[] usuarios_lectura = bas.Leer(archivo_de_bandera);






                // Verificar si el ID del programa actual coincide con el primer usuario en el archivo
                if (usuarios_lectura[0] == var_fun_GG.GG_id_programa)
                {
                    // Lee el archivo de los comandos a enviar al servidor
                    string[] respuestas_ia = bas.Leer(archivo_de_entrada_al_intermediario);

                    // Verificar si hay comandos 
                    if (respuestas_ia.Length > 1)
                    {
                        for (int i = G_donde_inicia_la_tabla; i < respuestas_ia.Length; i++)
                        {
                            conmutador conmut = new conmutador();
                            conmut.conmutar_datos(respuestas_ia[i]);

                        }

                        // Eliminar filas relacionadas con múltiples programas del archivo
                        
                        bas.limpiar_todo_el_archivo(archivo_de_entrada_al_intermediario, donde_inica: 1);

                        // Comentado: Reemplazo del archivo con un mensaje de "sin información"
                        // bas.cambiar_archivo_con_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_2[1]], new string[] { "sin_informacion" });
                    }

                    // Cambiar al siguiente ID de programa en la lista de usuarios
                    cambiar_id_programa_al_siguiente(archivo_de_bandera, usuarios_lectura);
                }
            }
        }


        public void cambiar_id_programa_al_siguiente(string direccion_archivo, string[] usuarios)
        {

            if (usuarios[0] == var_fun_GG.GG_id_programa)
            {
                int id_nuevo = 0;
                for (int i = G_donde_inicia_la_tabla; i < usuarios.Length; i++)
                {
                    if (usuarios[i] == var_fun_GG.GG_id_programa)
                    {
                        if (i >= (usuarios.Length - 1))
                        {
                            id_nuevo = 1;
                            break;
                        }
                        else
                        {
                            id_nuevo = i + 1;
                            break;
                        }
                    }
                }
                if (usuarios.Length > 2)
                {
                    bas.Editar_fila_espesifica_SIN_ARREGLO_GG(direccion_archivo, 0, usuarios[id_nuevo]);
                }


            }

        }

        public void quitar_id_prog_del_archivo()
        {
            for (int j = 0; j < G_dir_y_datos_de_arch_transferencia.GetLength(0); j++)
            {

                try
                {
                    
                    bas.eliminar_fila_PARA_MULTIPLES_PROGRAMAS(G_dir_y_datos_de_arch_transferencia[j, 4], 0, var_fun_GG.GG_id_programa);
                    string[] nueva_info_arch = bas.Leer(G_dir_y_datos_de_arch_transferencia[j, 4]);

                }
                catch
                {    
                }

            }
        }





    }
}
