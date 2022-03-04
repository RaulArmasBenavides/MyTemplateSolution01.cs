
using MyTemplateSolution01.Controller;
using MyTemplateSolution01.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTemplateSolution01.View
{
    public partial class ProductoView : Form
    {
        public ProductoView()
        {
            InitializeComponent();
            verProducto();
        }

        //instanciar objeto de la clase ProductoBll
        ProductoBll obj = new ProductoBll();

        //cariable de la clase producto
        Producto pro;

        private void verProducto()
        {
            dgvProducto.DataSource = null; 
            dgvProducto.DataSource = obj.ProductoListar();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            procesar(1);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            procesar(2);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            procesar(3);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            procesar(4);
        }                

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void procesar(int v)
        {
            string msg = "";
            switch (v)
            {
                case 1:
                    obj.ProductoAdicionar(leerDatos());
                    msg = "Producto registrado con exito";
                    break;
                case 2:
                    obj.ProductoActualizar(leerDatos());
                    msg = "Producto actualizado con exito";
                    break;
                case 3:
                    obj.ProductoEliminar(leerDatos());
                    msg = "Producto eliminado con exito";
                    break;
                case 4:
                    mostrarProducto();
                    return;
            }
            MessageBox.Show(msg, "exito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            verProducto();
        }

        private void mostrarProducto()
        {
            pro = obj.ProductoBuscar(int.Parse(txtID.Text));
            if (pro != null)
            {
                txtNombre.Text = pro.Nombre;
                txtPrecio.Text = pro.Precio.ToString();
                txtCantidad.Text = pro.Stock.ToString();
                cboCategoria.Text = pro.Categoria;
            }
            else
            {
                MessageBox.Show("Producto no existe", "aviso");
            }
        }

        private Producto leerDatos()
        {
            //crear objeto pro
            pro = new Producto();
            //asignar valores al objeto pro
            pro.ID = int.Parse(txtID.Text);
            pro.Nombre = txtNombre.Text;
            pro.Categoria = cboCategoria.Text;
            pro.Precio = decimal.Parse(txtPrecio.Text);
            pro.Stock = int.Parse(txtCantidad.Text);
            return pro;
        }

        private void button1_Click(object sender, EventArgs e)
        {
             dgvProducto.DataSource= obj.readProductsCondition(obj.ProductoListar());
        }
    }
}
