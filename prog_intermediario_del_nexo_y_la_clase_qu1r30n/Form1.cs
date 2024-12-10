using prog_intermediario_del_nexo_y_la_clase_qu1r30n.conexion.herramientas_internet;
using prog_intermediario_del_nexo_y_la_clase_qu1r30n.sin_internet.sin_formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prog_intermediario_del_nexo_y_la_clase_qu1r30n
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            iniciar_archivos inicio = new iniciar_archivos();
            inicio.iniciar();

            
        }

        private void btn_proceso_Click(object sender, EventArgs e)
        {
            string info_resultado = null;

            conexiones con = new conexiones();
            //con.quitar_id_prog_del_archivo();

            while (true)
            {
                con.datos_recibidos_a_procesar_y_borrar();
                Thread.Sleep(2000);
            }

        }
    }
}
