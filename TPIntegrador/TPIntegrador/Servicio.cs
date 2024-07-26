/*
 * Creado por SharpDevelop.
 * Usuario: Ursula
 * Fecha: 19/5/2024
 * Hora: 13:41
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace TPIntegrador
{
	/// <summary>
	/// Description of Servicio.
	/// </summary>
	public class Servicio
	{
		private int idServicio;
		private string nombre, descripcion;
		private float costo;
		
		public Servicio(int id, string nom, string des, float cost)
		{
			this.idServicio = id;
			this.nombre = nom;
			this.descripcion = des;
			this.costo =  cost;
		}
		
		public int IdServicio
		{
			get{ return idServicio; }
		}
		
		public string Nombre
		{
			set{this.nombre = value;}
			get{return nombre;}
		}
		
		public string Descripcion
		{
			set{this.descripcion = value;}
			get{return descripcion;}
		}
		
		public float Costo
		{
			set{this.costo = value;}
			get{return costo;}
		}
	}
}
