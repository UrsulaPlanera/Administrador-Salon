/*
 * Creado por SharpDevelop.
 * Usuario: Ursula
 * Fecha: 18/5/2024
 * Hora: 23:35
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;

namespace TPIntegrador
{
	/// <summary>
	/// Description of Salon.
	/// </summary>
	public class Salon
	{
		private ArrayList listaEmpleados;
		private ArrayList listaEncargados;
		private ArrayList listaAuxiliarEmp;
		private ArrayList listaEventos;
		private ArrayList listaServicios;
		private int idSalon;
		
		public Salon(int id)
		{
			this.idSalon = id;
			listaEmpleados = new ArrayList();
			listaEncargados = new ArrayList();
			listaAuxiliarEmp = new ArrayList();
			listaEventos = new ArrayList();
			listaServicios = new ArrayList();
		}
		
		public void AñadirServicio(string nom, string des, float cost)
		{
			int id;
			id = 1;
			if(listaServicios.Count > 0)
			{
				foreach(Servicio elem in listaServicios)
				{
					if(id <= elem.IdServicio)
					{
						id = elem.IdServicio;
					}
				}
				id++;
			}
			Servicio serv = new Servicio(id, nom, des, cost);
			listaServicios.Add(serv);
		}
		
		public void EliminarServicio(Servicio elem)
		{
			listaServicios.Remove(elem);
		}
		
		public Servicio ObtenerServicio(int id)
		{
			Servicio aux = null;
			foreach(Servicio elem in listaServicios)
			{
				if(elem.IdServicio == id)
				{
					aux = elem;
				}
			}
			return aux;
		}
		
		public int TotalServicios()
		{
			int total = listaServicios.Count;
			return total;
		}
		
		public bool ServiciosEsVacio()
		{
			bool esVacio = false;
			if(listaServicios.Count == 0)
			{
				esVacio = true;
			}
			return esVacio;
		}
		
		public void VerServicio(int id)
		{
			foreach(Servicio elem in listaServicios)
			{
				if(elem.IdServicio == id)
				{
					Console.WriteLine("{0} | {1} | {2} | {3}", elem.IdServicio, elem.Nombre, elem.Descripcion, elem.Descripcion);
				}
			}
		}
		
		public void AltaEmpleado(string nom, string ape, string doc, string tar, float suel)
		{
			int leg;
			leg = -1;
			if(listaEmpleados.Count == 0)
			{
				leg = 1;
			}
			else
			{
				foreach(Empleado elem in ListaEmpleados)
				{
					if(elem.Legajo >= leg)
					{
						leg=elem.Legajo;
					}
				}
				foreach(Encargado elem in listaEncargados)
				{
					if(elem.Legajo >= leg)
					{
						leg=elem.Legajo;
					}
				}
				leg++;
			}
			Empleado emp = new Empleado(leg, nom, ape, doc, tar, suel);
			listaEmpleados.Add(emp);
		}
		
		public void BajaEmpleado(Empleado emp)
		{
			listaEmpleados.Remove(emp);
		}
		
		public Empleado ObtenerEmpleado(int legajo)
		{
			Empleado aux = null;
			foreach(Empleado elem in listaEmpleados)
			{
				if(elem.Legajo == legajo)
				{
					aux = elem;
				}
			}
			return aux;
		}
		
		public int TotalEmpleados()
		{
			int total = listaEmpleados.Count;
			return total;
		}
		
		public bool EmpleadosEsVacio()
		{
			bool esVacio = false;
			if(listaEmpleados.Count == 0)
			{
				esVacio = true;
			}
			return esVacio;
		}
		
		public void VerEmpleado(int legajo)
		{
			foreach(Empleado elem in listaEmpleados)
			{
				if(elem.Legajo == legajo)
				{
					Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5}", elem.Legajo, elem.Nombre, elem.Apellido, elem.DNI, elem.Tarea, elem.Sueldo);
				}
			}
		}
		
		public void AltaEncargado(Empleado emp, float plus)
		{
			Encargado enc = new Encargado(emp.Legajo, emp.Nombre, emp.Apellido, emp.DNI, "Encargado", emp.Sueldo, plus);
			listaEncargados.Add(enc);
			listaEmpleados.Remove(emp);
			listaAuxiliarEmp.Add(emp);
		}
		
		public void BajaEncargado(Encargado enc, string condicionDeBaja)
		{
			Empleado aux;
			aux = null;
			foreach(Empleado elem in listaAuxiliarEmp)
			{
				if((elem.Legajo) == (enc.Legajo))
				{
					aux=elem;
				}
			}
			listaEncargados.Remove(enc);
			if(condicionDeBaja == "s")
			{
				listaEmpleados.Add(aux);
				listaAuxiliarEmp.Remove(aux);
				
			}
			if(condicionDeBaja == "t")
			{
				listaAuxiliarEmp.Remove(aux);
			}
		}
		
		public Encargado ObtenerEncargado(int legajo)
		{
			Encargado aux = null;
			foreach(Encargado elem in listaEncargados)
			{
				if(elem.Legajo == legajo)
				{
					aux = elem;
				}
			}
			return aux;
		}
		
		public int TotalEncargados()
		{
			int total = listaEncargados.Count;
			return total;
		}
		
		public bool EncargadosEsVacio()
		{
			bool esVacio = false;
			if(listaEncargados.Count == 0)
			{
				esVacio = true;
			}
			return esVacio;
		}
		
		public void VerEncargado(int legajo)
		{
			foreach(Encargado elem in listaEncargados)
			{
				if(elem.Legajo == legajo)
				{
					Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5}", elem.Legajo, elem.Nombre, elem.Apellido, elem.DNI, elem.Tarea, elem.SueldoEncargado);
				}
			}
		}
		
		public void AñadirReservaEvento(string nombre, string dni, string tipo, int encargado, DateTime fechayhora, ArrayList servicios, float costo, float seña)
		{
			int id = 1;
			if(listaEventos.Count > 0)
			{
				foreach(Evento elem in listaEventos)
				{
					if(id <= elem.IdEvento)
					{
						id=elem.IdEvento;
					}
					id++;
				}
			}
			Evento aux = new Evento(id, nombre, dni, tipo, encargado, fechayhora, servicios, costo, seña);
			listaEventos.Add(aux);
		}
		
		public void CancelarReservaEvento(Evento elem)
		{
			listaEventos.Remove(elem);
		}
		
		public Evento ObtenerEvento(int id)
		{
			Evento aux = null;
			foreach(Evento elem in listaEventos)
			{
				if(elem.IdEvento == id)
				{
					aux = elem;
				}
			}
			return aux;
		}
		
		public int TotalEventos()
		{
			int total = listaEventos.Count;
			return total;
		}
		
		public bool EventosEsVacio()
		{
			bool esVacio = false;
			if(listaEventos.Count == 0)
			{
				esVacio = true;
			}
			return esVacio;
		}
		
		public void VerEvento(int id)
		{
			foreach(Evento evento in listaEventos)
			{
				if(evento.IdEvento == id)
				{
					Console.WriteLine("ID: {0} | Cliente: {1} | DNI: {2} | Tipo de Evento: {3} | {4} | Encargado: {5}", evento.IdEvento, evento.ClienteNombre, evento.ClienteDNI, evento.TipoEvento, evento.FechayHora, evento.EncargadoEvento);
					Console.WriteLine("Lista de servicios contratados:");
					foreach(int servicioCont in evento.ServiciosContratados)
					{
						foreach(Servicio servicio in listaServicios)
						{
							if(servicioCont == servicio.IdServicio)
							{
								Console.WriteLine("{0} | {1} | {2} | {3}", servicio.IdServicio, servicio.Nombre, servicio.Descripcion, servicio.Costo);
							}
						}
					}
					Console.WriteLine("Costo Total: {0} | Seña: {1}",evento.CostoTotal, evento.SeñaEvento);
				}
			}
		}
		
		public int IdSalon
		{
			set { this.idSalon = value; }
			get { return idSalon; }
		}
		
		public ArrayList ListaEmpleados
		{
			get{ return listaEmpleados;}
		}
		
		public ArrayList ListaEncargados
		{
			get{return listaEncargados;}
		}
		
		public ArrayList ListaEventos
		{
			get{return listaEventos;}
		}
		
		public ArrayList ListaServicios
		{
			get{return listaServicios;}
		}
	}
}
