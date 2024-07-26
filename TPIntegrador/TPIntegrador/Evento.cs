/*
 * Creado por SharpDevelop.
 * Usuario: Ursula
 * Fecha: 22/5/2024
 * Hora: 23:12
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;

namespace TPIntegrador
{
	/// <summary>
	/// Description of Evento.
	/// </summary>
	public class Evento
	{
		private string clienteNombreyApe, tipoEvento, clienteDNI;
		private int encargadoEvento, idEvento;
		private DateTime fechayhora;
		private float costoTotal, seña;
		private ArrayList serviciosSolicitados;
		
		public Evento(int id, string nombre, string doc, string tipoEvent, int encargado, DateTime fyh, ArrayList servs, float costo, float señ)
		{
			this.idEvento = id;
			this.clienteNombreyApe = nombre;
			this.clienteDNI = doc;
			this.tipoEvento = tipoEvent;
			this.encargadoEvento = encargado;
			this.fechayhora = fyh;
			this.costoTotal = costo;
			this.seña = señ;
			this.serviciosSolicitados = servs;
		}
		
		public int IdEvento
		{
			get{return idEvento;}
		}
		
		public string ClienteNombre
		{
			set{this.clienteNombreyApe = value;}
			get{return clienteNombreyApe;}
		}
		
		public string ClienteDNI
		{
			set{this.clienteDNI = value;}
			get{return clienteDNI;}
		}
		
		public string TipoEvento
		{
			set{this.tipoEvento = value;}
			get{return tipoEvento;}
		}
		
		public int EncargadoEvento
		{
			set{this.encargadoEvento = value;}
			get{return encargadoEvento;}
		}
		
		public DateTime FechayHora
		{
			set{this.fechayhora=value;}
			get{return fechayhora;}
		}
		
		public ArrayList ServiciosContratados
		{
			get{return serviciosSolicitados;}
		}
		
		public float CostoTotal
		{
			set{this.costoTotal=value;}
			get{return costoTotal;}
		}
		
		public float SeñaEvento
		{
			set{this.seña=value;}
			get{return seña;}
		}
	}
}
