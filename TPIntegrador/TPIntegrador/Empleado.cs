/*
 * Creado por SharpDevelop.
 * Usuario: Ursula
 * Fecha: 19/5/2024
 * Hora: 13:22
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace TPIntegrador
{
	/// <summary>
	/// Description of Empleado.
	/// </summary>
	public class Empleado
	{
		protected int nroLegajo;
		protected string nombreEmpleado;
		protected string apellidoEmpleado;
		protected string dni;
		protected string tarea;
		protected float sueldo;
		
		public Empleado(int leg, string nom, string ape, string doc, string tar, float suel)
		{
			this.nroLegajo = leg;
			this.nombreEmpleado = nom;
			this.apellidoEmpleado = ape;
			this.dni = doc;
			this.tarea = tar;
			this.sueldo = suel;
		}
		
		public int Legajo
		{
			set{this.nroLegajo = value;}
			get{return nroLegajo;}
		}
		
		public string Nombre
		{
			set{this.nombreEmpleado = value;}
			get{return nombreEmpleado;}
		}
		
		public string Apellido
		{
			set{this.apellidoEmpleado = value;}
			get{return apellidoEmpleado;}
		}
		
		public string DNI
		{
			set{this.dni = value;}
			get{return dni;}
		}
		
		public string Tarea
		{
			set{this.tarea = value;}
			get {return tarea;}
		}
		
		public float Sueldo
		{
			set{this.sueldo = value;}
			get{return sueldo;}
		}
	}
}
