using Inventario.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.Formularios
{
    public partial class FormMarcas : Form
    {
        public Registro_TiendasEntities db = new Registro_TiendasEntities();
        int idMarca = 0;
        public FormMarcas()
        {
            InitializeComponent();
            cargarMarcas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() != "")
            {
                if (idMarca == 0)
                {
                    if (buscarNombre(txtNombre.Text.Trim()))
                    {
                        Marca marca = new Marca();
                        marca.nombre_marca = txtNombre.Text.Trim();
                        db.Marca.Add(marca);
                        db.SaveChanges();
                        limpiar();
                        cargarMarcas();
                    }
                    else
                    {
                        MessageBox.Show("La marca ya está registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (buscarNombre(txtNombre.Text.Trim()))
                    {
                        var marca = db.Marca.Find(idMarca);
                        if (marca != null)
                        {
                            marca.nombre_marca = txtNombre.Text;
                            db.SaveChanges();
                            limpiar();
                            cargarMarcas();
                        }
                    }
                    else
                    {
                        MessageBox.Show("La marca ya está registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe ingrese un nombre de marca");
            }
        }
        private bool buscarNombre(string nombre)
        {
            var q = db.Marca.FirstOrDefault(m => m.nombre_marca == nombre);
            if (q != null)
            {
                return false;
            }
            return true;
        }
        private void cargarMarcas()
        {
            var listaMarcas = db.Marca.ToList();
            dgvMarcas.DataSource = listaMarcas;
            dgvMarcas.Columns[2].Visible = false;
        }

        private void dgvMarcas_MouseClick(object sender, MouseEventArgs e)
        {
            idMarca = int.Parse(dgvMarcas.CurrentRow.Cells[0].Value.ToString());
            txtNombre.Text = dgvMarcas.CurrentRow.Cells[1].Value.ToString();

            btnEliminar.Enabled = true;
        }
        private void limpiar()
        {
            idMarca = 0;
            txtNombre.Text = "";
            dgvMarcas.ClearSelection();
            btnEliminar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idMarca > 0)
            {
                Marca marca = db.Marca.Find(idMarca);

                if (marca != null)
                {
                    
                    db.Marca.Remove(marca);
                    db.SaveChanges();
                    MessageBox.Show("Eliminado con éxito!");
                    limpiar();
                    cargarMarcas();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
