using DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI {
  public partial class FormPrincipal : Form {
    DL_BaseDatos asd = new DL_BaseDatos();
    public FormPrincipal() {
      InitializeComponent();
      ActualizarTabla();
    }

    private void button1_Click(object sender, EventArgs e) {
      ActualizarTabla();
    }

    private void ActualizarTabla() {
      dataGridView1.DataSource = asd.DevolverTabla("Clientes");
    }
  }
}
