using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class Tickets : Syncfusion.Windows.Forms.Office2010Form
    {
        public Tickets()
        {
            InitializeComponent();
        }

        TicketBD ticketBD = new TicketBD();
        Ticket ticket = new Ticket();
        private void UsuarioTextBox_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, System.EventArgs e)
        {
            ticket.Codigo = CodigoTextBox.Text;
            ticket.Fecha = dateTimePicker1.Value;
            ticket.CodigoUsuario = UsuarioTextBox.Text;
            ticket.Cliente = ClienteTextBox.Text;
            ticket.TipoSoporte = TipoSoporteTextBox.Text;
            ticket.DescripcionSolicitud = SolicitudTextBox.Text;
            ticket.DescripcionRespuesta = RespuestaTextBox.Text;
            ticket.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            ticket.ISV = Convert.ToDecimal(ImpuestoTextBox.Text);
            ticket.Descuento = Convert.ToDecimal(DescuentoTextBox.Text);
            ticket.Total = Convert.ToDecimal(TotalTextBox.Text);

            bool inserto = ticketBD.Insertar(ticket);
            if (inserto)
            {
                LimpiarControles();
                DeshabilitarControles();
                MessageBox.Show("Registro guardado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el registro", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataGridView1.DataSource = ticketBD.MostrarTickets();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                ticket.Codigo = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                ticket.Fecha = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Fecha"].Value);
                ticket.CodigoUsuario = dataGridView1.CurrentRow.Cells["CodigoUsuario"].Value.ToString();
                ticket.Cliente = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
                ticket.TipoSoporte = dataGridView1.CurrentRow.Cells["TipoSoporte"].Value.ToString();
                ticket.DescripcionSolicitud = dataGridView1.CurrentRow.Cells["DescripcionSolicitud"].Value.ToString();
                ticket.DescripcionRespuesta = dataGridView1.CurrentRow.Cells["DescripcionRespuesta"].Value.ToString();
                ticket.Precio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Precio"].Value);
                ticket.ISV = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Impuesto"].Value);
                ticket.Descuento = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Descuento"].Value);
                ticket.Total = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Total"].Value);
                this.Close();
            }

        }

        private void DeshabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            UsuarioTextBox.Enabled = false;
            ClienteTextBox.Enabled = false;
            TipoSoporteTextBox.Enabled = false;
            SolicitudTextBox.Enabled = false;
            RespuestaTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
            ImpuestoTextBox.Enabled = false;
            DescuentoTextBox.Enabled = false;
            TotalTextBox.Enabled = false;
        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            UsuarioTextBox.Clear();
            ClienteTextBox.Clear();
            TipoSoporteTextBox.Clear();
            SolicitudTextBox.Clear();
            RespuestaTextBox.Clear();
            PrecioTextBox.Clear();
            ImpuestoTextBox.Clear();
            DescuentoTextBox.Clear();
            TotalTextBox.Clear();
        }

        private void MostrarButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ticketBD.MostrarTickets();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                ticket.Codigo = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                ticket.Fecha = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Fecha"].Value);
                ticket.CodigoUsuario = dataGridView1.CurrentRow.Cells["CodigoUsuario"].Value.ToString();
                ticket.Cliente = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
                ticket.TipoSoporte = dataGridView1.CurrentRow.Cells["TipoSoporte"].Value.ToString();
                ticket.DescripcionSolicitud = dataGridView1.CurrentRow.Cells["DescripcionSolicitud"].Value.ToString();
                ticket.DescripcionRespuesta = dataGridView1.CurrentRow.Cells["DescripcionRespuesta"].Value.ToString();
                ticket.Precio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Precio"].Value);
                ticket.ISV = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Impuesto"].Value);
                ticket.Descuento = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Descuento"].Value);
                ticket.Total = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Total"].Value);
                this.Close();
            }
        }

        private void NuevoTextBox_Click(object sender, EventArgs e)
        {
            CodigoTextBox.Focus();
            HabilitarControles();
        }

        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            UsuarioTextBox.Enabled = true;
            ClienteTextBox.Enabled = true;
            TipoSoporteTextBox.Enabled = true;
            SolicitudTextBox.Enabled = true;
            RespuestaTextBox.Enabled = true;
            PrecioTextBox.Enabled = true;
            ImpuestoTextBox.Enabled = true;
            DescuentoTextBox.Enabled = true;
            TotalTextBox.Enabled = true;
        }

        private void Tickets_Load(object sender, EventArgs e)
        {
            DeshabilitarControles();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Esta seguro de eliminar el registro", "Advertencia", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    bool elimino = ticketBD.Eliminar(dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString());

                    if (elimino)
                    {
                        LimpiarControles();
                        DeshabilitarControles();
                        MessageBox.Show("Registro eliminado");
                    }
                    else
                    { MessageBox.Show("No se pudo eliminar el registro"); }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }
    }
}
