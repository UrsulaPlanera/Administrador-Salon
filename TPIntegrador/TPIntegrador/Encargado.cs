/*
 * Creado por SharpDevelop.
 * Usuario: Ursula
 * Fecha: 19/5/2024
 * Hora: 22:19
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace TPIntegrador
{
	/// <summary>
	/// Description of Encargado.
	/// </summary>
	public class Encargado:Empleado
	{
		private float sueldoEncargado;
		
		public Encargado(int leg, string nom, string ape, string doc, string tar, float suel, float plus) : base(leg, nom, ape, doc,  tar, suel)
		{
			this.sueldoEncargado = suel + plus;
		}
		
		public float SueldoEncargado
		{
			set{sueldoEncargado = value;}
			get{return sueldoEncargado;}
		}
	}
}
