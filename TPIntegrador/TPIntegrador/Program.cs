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
	class Program
	{
		public static void Main(string[] args)
		{
			int cont, opcionElegida, opcionSubmenu;
			string [] opcionesMenu;
			string [] opcionesListas;
			Salon salon;
			salon = new Salon(1);
			
			DateTime fechaActual = DateTime.Now;
			
			Console.WindowWidth = 130;
			
			//datos de prueba
			
			salon.AñadirServicio("Catering", "2 Mozos, 1 Bartender", 350000);
			salon.AñadirServicio("Catering Simple", "2 Mozos", 250000);
			salon.AñadirServicio("Catering Completo", "3 Mozos, 1 Bartender, 1 Barista", 500000);
			salon.AñadirServicio("Maquillador Artístico Eventos Infantíles", "1 Maquillador", 200000);
			salon.AñadirServicio("Animador Evento Infantil", "1 Animador", 300000);
			
			salon.AltaEmpleado("Catalina", "Pérez", "40827300", "Mozo", 3500);
			salon.AltaEmpleado("Facundo Elias", "García", "44019228", "Mozo", 3500);
			salon.AltaEmpleado("Rocío", "Estebanez", "43927288", "Mozo", 3500);
			salon.AltaEmpleado("Mariana", "Coronel", "39128302", "Bartender", 5000);
			salon.AltaEmpleado("Mariano", "Salina", "40102224", "Bartender", 5000);
			salon.AltaEmpleado("Emanuel", "Ortiga", "39817203", "Barista", 6000);
			
			Empleado empPrueba = salon.ObtenerEmpleado(2);
			salon.AltaEncargado(empPrueba, 3000);
			
			//terminan los datos de prueba
			
			while(true)
			{
				Console.Clear();
				Mensaje("cyan", "Menu\n----");
				opcionesMenu = new string[8]{"Añadir servicio", "Eliminar servicio", "Alta empleado/Encargado", "Baja empleado/Encargado", "Agendar reserva", "Cancelar reserva", "Ver Información", "Salir del programa"};
				cont=1;
				foreach(string elem in opcionesMenu)
				{
					Console.WriteLine("{0}. {1}", cont, elem);
					cont++;
				}
				bool esNumero = false;
				opcionElegida = -1;
				while(!esNumero)
				{
					try
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write("Seleccione una opción. >> ");
						Console.ForegroundColor = ConsoleColor.White;
						opcionElegida = int.Parse(Console.ReadLine());
						if((opcionElegida < 1) || (opcionElegida > 8))
						{
							throw new ArgumentOutOfRangeException();
						}
						else
						{
							esNumero = true;
						}
					}
					catch(FormatException)
					{
						Mensaje("red", "Solo puede ingresar números.");
					}
					catch(ArgumentOutOfRangeException)
					{
						Mensaje("red", "Ingrese un número válido.");
					}
					catch(OverflowException)
					{
						Mensaje("red", "Cantidad de carácteres inválida.");
					}
				}
				switch(opcionElegida)
				{
					case 1:
						{
							AñadirServicio(salon);break;
						}
					case 2:
						{
							EliminarServicio(salon);break;
						}
					case 3:
						{
							while(true)
							{
								Console.Clear();
								Mensaje("cyan", "Alta de Empleado/Encargado\n--------------------------");
								Console.WriteLine("1. Alta de empleado");
								Console.WriteLine("2. Alta de encargado");
								Console.WriteLine("3. Volver al menu principal");
								esNumero = false;
								opcionSubmenu = -1;
								while(!esNumero)
								{
									try
									{
										Console.Write("Opcion >> ");
										opcionSubmenu = int.Parse(Console.ReadLine());
										if((opcionSubmenu > 3) || (opcionSubmenu < 1))
										{
											throw new ArgumentOutOfRangeException();
										}
										esNumero = true;
									}
									catch(FormatException)
									{
										Mensaje("red", "Solo puede ingresar números.");
									}
									catch(ArgumentOutOfRangeException)
									{
										Mensaje("red", "Ingrese un carácter válido.");
									}
									catch(OverflowException)
									{
										Mensaje("red", "Cantidad de carácteres inválida.");
									}
								}
								switch(opcionSubmenu)
								{
										case 1: AltaEmpleado(salon);break;
										case 2: AltaEncargado(salon);break;
								}
								if(opcionSubmenu == 3)
								{
									break;
								}
							}
							break;
						}
					case 4:
						{
							while(true)
							{
								Console.Clear();
								Mensaje("cyan", "Baja de Empleado/Encargado\n------");
								Console.WriteLine("1. Baja de empleado");
								Console.WriteLine("2. Baja de encargado");
								Console.WriteLine("3. Volver al menu principal");
								esNumero = false;
								opcionSubmenu = -1;
								while(!esNumero)
								{
									try
									{
										Console.Write("Opcion >> ");
										opcionSubmenu = int.Parse(Console.ReadLine());
										if((opcionSubmenu > 3) || (opcionSubmenu < 1))
										{
											throw new ArgumentOutOfRangeException();
										}
										esNumero = true;
									}
									catch(FormatException)
									{
										Mensaje("red", "Solo puede ingresar números.");
									}
									catch(ArgumentOutOfRangeException)
									{
										Mensaje("red", "Ingrese un carácter válido.");
									}
									catch(OverflowException)
									{
										Mensaje("red", "Cantidad de carácteres inválida.");
									}
								}
								switch(opcionSubmenu)
								{
										case 1: BajaEmpleado(salon);break;
										case 2: BajaEncargado(salon);break;
								}
								if(opcionSubmenu == 3)
								{
									break;
								}
							}
							break;
						}
					case 5: AñadirReserva(salon, fechaActual);break;
					case 6: CancelarEvento(salon, fechaActual);break;
					case 7:
						{
							while(true)
							{
								Console.Clear();
								Mensaje("cyan", "Listas\n------");
								opcionesListas = new string[5] {"Listado de eventos","Listado de clientes","Listado de empleados","Listado de eventos por mes","Regresar al menu principal"};
								cont = 1;
								foreach(string elem in opcionesListas)
								{
									Console.WriteLine("{0}. {1}", cont, elem);
									cont++;
								}
								esNumero = false;
								opcionSubmenu = -1;
								while(!esNumero)
								{
									try
									{
										Console.ForegroundColor = ConsoleColor.Yellow;
										Console.Write("Seleccione una opción. >> ");
										Console.ForegroundColor = ConsoleColor.White;
										opcionSubmenu = int.Parse(Console.ReadLine());
										if((opcionSubmenu < 1) || (opcionSubmenu > 5))
										{
											throw new ArgumentOutOfRangeException();
										}
										else
										{
											esNumero = true;
										}
									}
									catch(FormatException)
									{
										Mensaje("red", "Solo puede ingresar números.");
									}
									catch(ArgumentOutOfRangeException)
									{
										Mensaje("red", "Ingrese un carácter válido.");
									}
									catch(OverflowException)
									{
										Mensaje("red", "Cantidad de carácteres inválida.");
									}
								}
								switch(opcionSubmenu)
								{
									case 1: 
										{
											MostrarEventos(salon.ListaEventos, salon.ListaServicios);
											Console.WriteLine("Continuar...");
											break;
										}
									case 2:
										{
											if(salon.ListaEventos.Count == 0)
											{
												Mensaje("red", "No hay clientes registrados en este momento.");
											}
											else
											{
												Console.WriteLine("Orden | Nombre de Cliente | DNI");
												ArrayList clientes = new ArrayList();
												foreach(Evento elem in salon.ListaEventos)
												{
													if(!clientes.Contains(elem.ClienteDNI))
													{
														clientes.Add(elem.ClienteDNI);
														Console.WriteLine("ID Asociado: {0} | Nombre: {1} | DNI: {2}", elem.IdEvento, elem.ClienteNombre,elem.ClienteDNI);
													}
												}
												Console.WriteLine("Continuar...");
											}
											Console.ReadKey();
											break;
										}
									case 3:
										{
											MostrarEmpleados("mixto", salon.ListaEmpleados, salon.ListaEncargados);
											Console.ReadKey();
											break;
										}
									case 4:
										{
											ArrayList eventosAuxiliar;
											int mes, anio;
											esNumero = false;
											if(salon.ListaEventos.Count > 0)
											{
												Mensaje("cyan", "Buscar Eventos por Mes\n----------------------");
												mes = -1; anio=-1;
												while(!esNumero)
												{
													try
													{
														Console.Write("Ingrese el mes (numero) >> ");
														mes = int.Parse(Console.ReadLine());
														if((mes > 12) || (mes < 1))
														{
															throw new ArgumentOutOfRangeException();
														}
														esNumero = true;
													}
													catch(FormatException)
													{
														Mensaje("red", "Solo puede ingresar números.");
													}
													catch(ArgumentOutOfRangeException)
													{
														Mensaje("red", "El mes ingresado no es válido.");
													}
													catch(OverflowException)
													{
														Mensaje("red", "Cantidad de carácteres inválida.");
													}
												}
												esNumero = false;
												while(!esNumero)
												{
													try
													{
														Console.Write("Ingrese el año (formato YYYY) >> ");
														anio = int.Parse(Console.ReadLine());
														if(anio.ToString().Length < 4)
														{
															throw new ArgumentOutOfRangeException();
														}
														esNumero = true;
													}
													catch(FormatException)
													{
														Mensaje("red", "Solo puede ingresar números.");
													}
													catch(ArgumentOutOfRangeException)
													{
														Mensaje("red", "El año ingresado no es válido.");
													}
													catch(OverflowException)
													{
														Mensaje("red", "Cantidad de carácteres inválida.");
													}
												}
												eventosAuxiliar = new ArrayList();
												foreach(Evento elem in salon.ListaEventos)
												{
													if((elem.FechayHora.Month == mes) && (elem.FechayHora.Year == anio))
													{
														eventosAuxiliar.Add(elem);
													}
												}
												if(eventosAuxiliar.Count > 0)
												{
													MostrarEventos(eventosAuxiliar, salon.ListaServicios);
												}
												else
												{
													Mensaje("red", "No se han encontrado eventos en la fecha ingresada.");
												}
											}
											else
											{
												Mensaje("red", "No hay eventos agendados.");
											}
											Console.ReadKey();
											break;
										}
								}
								if(opcionSubmenu == 5)
								{
									break;
								}
							}
							break;
						}
				}
				if(opcionElegida == 8)
				{
					Console.WriteLine("Toque cualquier tecla para finalizar...");
					Console.ReadKey();
					break;
				}
			}
		}
		
		static void AñadirServicio(Salon s)
		{
			string nombre, descripcion, confirmar;
			float costoUnit;
			bool esNombre, esDescripcion, esNumero;
			
			Console.Clear();
			Mensaje("cyan", "Añadir Servicio\n---------------");
			esNombre = false;
			nombre = null;
			while(!esNombre)
			{
				try
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write("Ingresar nombre o 'V' para regresar al menu >> ");
					Console.ForegroundColor = ConsoleColor.White;
					nombre = Console.ReadLine();
					if(nombre.Length == 0)
					{
						throw new NullReferenceException();
					}
					if(nombre.Length > 28)
					{
						throw new ArgumentOutOfRangeException();
					}
					esNombre = true;
				}
				catch(NullReferenceException)
				{
					Mensaje("red","No puede ingresar campos vacios.");
				}
				catch(ArgumentOutOfRangeException)
				{
					Mensaje("red","El nombre no puede contener más de 28 caracteres.");
				}
			}
			while(nombre != "V" && nombre != "v")
			{
				descripcion = null;
				esDescripcion = false;
				while(!esDescripcion)
				{
					try
					{
						Console.Write("Descripcion >> ");
						descripcion = Console.ReadLine();
						if(descripcion.Length == 0)
						{
							throw new NullReferenceException();
						}
						if(descripcion.Length > 100)
						{
							throw new ArgumentOutOfRangeException();
						}
						esDescripcion = true;
					}
					catch(NullReferenceException)
					{
						Mensaje("red","No puede ingresar campos vacios.");
					}
					catch(ArgumentOutOfRangeException)
					{
						Mensaje("red", "La descripcion no puede contener más de 100 caracteres.");
					}
				}
				esNumero = false;
				costoUnit = 0;
				while(!esNumero)
				{
					try
					{
						Console.Write("Precio de servicio >> $");
						costoUnit = float.Parse(Console.ReadLine());
						if(costoUnit.ToString().Length > 10)
						{
							throw new ArgumentOutOfRangeException();
						}
						esNumero = true;
					}
					catch(FormatException)
					{
						Mensaje("red", "Solo puede ingresar números.");

					}
					catch(ArgumentOutOfRangeException)
					{
						Mensaje("red", "Numero fuera de rango.");
					}
				}
				Console.Write("Datos Ingresados:\nNombre: {0}\nDescripcion: {1}\nCosto: ${2}\n¿Desea confirmar la carga del servicio? (S/n) >> ", nombre, descripcion, costoUnit);
				bool termina = false;
				confirmar = Console.ReadLine();
				while(!termina)
				{
					if(confirmar == "S" || confirmar == "s")
					{
						s.AñadirServicio(nombre, descripcion, costoUnit);
						termina = true;
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("Servicio añadido al sistema.");
						Console.ForegroundColor = ConsoleColor.White;
						Console.ReadKey();
						AñadirServicio(s);
					}
					else if(confirmar == "N" || confirmar == "n")
					{
						termina = true;
						AñadirServicio(s);
					}
					else
					{
						Mensaje("red", "Ingrese un carácter válido.");
						Console.Write("Datos Ingresados:\nNombre: {0}\nDescripcion: {1}\nCosto: ${2}\n¿Desea confirmar la carga del servicio? (S/n) >> ", nombre, descripcion, costoUnit);
						confirmar = Console.ReadLine();
					}
				}
				break;
			}
		}
		
		static void EliminarServicio(Salon s)
		{
			string confirmarEli;
			Servicio aux;
			int opcionEli;
			bool esNumero, confirmar;
			
			if(s.ServiciosEsVacio())
			{
				Mensaje("red","No hay servicios por eliminar.");
				Console.WriteLine("Toque cualquier tecla para continuar...");
				Console.ReadKey();
			}
			else
			{
				Console.Clear();
				
				Mensaje("cyan", "Eliminar Servicio\n-----------------");
				Console.WriteLine("Seleccione el servicio que desea eliminar: ");
				MostrarServicios(s.ListaServicios);
				esNumero = false;
				opcionEli = -1;
				while(!esNumero)
				{
					try
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write("(Para cancelar y regresar al menu ingrese 0) >> ");
						Console.ForegroundColor = ConsoleColor.White;
						opcionEli = int.Parse(Console.ReadLine());
						if(opcionEli < 0)
						{
							throw new IndexOutOfRangeException();
						}
						esNumero = true;
					}
					catch(FormatException)
					{
						Mensaje("red", "Solo puede ingresar números.");
					}
					catch(IndexOutOfRangeException)
					{
						Mensaje("red", "Ingrese un número válido.");
					}
					catch(OverflowException)
					{
						Mensaje("red", "Cantidad de carácteres inválida.");
					}
				}
				while(opcionEli != 0)
				{
					aux = null;
					foreach(Servicio elem in s.ListaServicios)
					{
						if(elem.IdServicio == opcionEli)
						{
							aux = elem;
						}
					}
					confirmar = false;
					while(!confirmar)
					{
						try
						{
							Console.Write("Elemento seleccionado:\nNombre: {0}\nDescripcion: {1}\nCosto: {2}\n¿Confirmar la eliminación del servicio? (S/n) >> ", aux.Nombre, aux.Descripcion, aux.Costo);
							confirmarEli = Console.ReadLine();
							if((confirmarEli == "S") || (confirmarEli == "s"))
							{
								s.EliminarServicio(aux);
								Console.ForegroundColor = ConsoleColor.Green;
								Console.WriteLine("Servicio eliminado con éxito.");
								Console.ForegroundColor = ConsoleColor.White;
								confirmar = true;
								EliminarServicio(s);
							}
							else if((confirmarEli == "N") || (confirmarEli == "n"))
							{
								confirmar = true;
								EliminarServicio(s);
							}
							else
							{
								throw new IndexOutOfRangeException();
							}
						}
						catch(IndexOutOfRangeException)
						{
							Mensaje("red", "Ingrese un carácter válido.");
						}
						catch(NullReferenceException)
						{
							confirmar = true;
							EliminarServicio(s);
						}
					}
					break;
				}
			}
			
		}
		
		static void AltaEmpleado(Salon s)
		{
			string nombre, apellido, tareaS, sueldoS, confirmar;
			int tarea, documento;
			float sueldo;
			bool esNumero, esNombre, esApellido, esDocumento, termina;
			
			Console.Clear();
			
			Mensaje("cyan", "Gestion de Alta de Empleado\n---------------------------");
			
			esNombre = false;
			nombre = null;
			while(!esNombre)
			{
				try
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write("Ingresar nombre o 'V' para regresar al menú >> ");
					Console.ForegroundColor = ConsoleColor.White;
					nombre = Console.ReadLine();
					if(nombre.Length == 0)
					{
						throw new ArgumentNullException();
					}
					if(nombre.Length > 28)
					{
						throw new ArgumentOutOfRangeException();
					}
					esNombre = true;
				}
				catch(ArgumentNullException)
				{
					Mensaje("red","No puede ingresar campos vacios.");
				}
				catch(ArgumentOutOfRangeException)
				{
					Mensaje("red","No se admiten mas de 28 caracteres.");
				}
			}
			while(nombre != "V" && nombre != "v")
			{
				apellido = null;
				esApellido = false;
				while(!esApellido)
				{
					try
					{
						Console.Write("Apellido >> ");
						apellido = Console.ReadLine();
						if(apellido.Length == 0)
						{
							throw new ArgumentNullException();
						}
						if(apellido.Length > 28)
						{
							throw new ArgumentOutOfRangeException();
						}
						esApellido = true;
					}
					catch(ArgumentNullException)
					{
						Mensaje("red","No puede ingresar campos vacios.");
					}
					catch(ArgumentOutOfRangeException)
					{
						Mensaje("red","No se admiten mas de 28 caracteres.");
					}	
				}
				esDocumento = false;
				documento = -1;
				while(!esDocumento)
				{
					try
					{
						Console.Write("DNI >> ");
						documento = int.Parse(Console.ReadLine());
						if(documento.ToString().Length == 0)
						{
							throw new ArgumentNullException();
						}
						if((documento.ToString().Length > 8) || (documento.ToString().Length < 7))
						{
							throw new ArgumentOutOfRangeException();
						}
						esDocumento = true;
					}
					catch(FormatException)
					{
						Mensaje("red", "Solo puede ingresar números.");
					}
					catch(ArgumentNullException)
					{
						Mensaje("red","No puede ingresar campos vacios.");
					}
					catch(ArgumentOutOfRangeException)
					{
						Mensaje("red", "Ingrese un carácter válido.");
					}	
				}
				tareaS = null;
				tarea = 0;
				if(s.ListaEmpleados.Count == 0)
				{
					termina = false;
					while(!termina)
					{
						try
						{
							Console.Write("Ingresar tarea >> ");
							tareaS = Console.ReadLine();
							if(tareaS.Length == 0)
							{
								throw new ArgumentNullException();
							}
							if(tareaS.Length > 18)
							{
								throw new ArgumentOutOfRangeException();
							}
							termina = true;
						}
						catch(ArgumentNullException)
						{
							Mensaje("red","No puede ingresar campos vacios.");
						}
						catch(ArgumentOutOfRangeException)
						{
							Mensaje("red","Se permiten 18 caracteres máximo.");
						}
					}
				}
				else
				{
					Console.WriteLine("Seleccione o ingrese manualmente la tarea a realizar: ");
					ArrayList listaTareas = new ArrayList();
					foreach(Empleado emp in s.ListaEmpleados)
					{
						if(!listaTareas.Contains(emp.Tarea))
						{
							listaTareas.Add(emp.Tarea);
						}
					}
					listaTareas.Add("Ingresar manualmente");
					int cont = 1;
					foreach(string tar in listaTareas)
					{
						Console.WriteLine("{0}.\t{1}", cont++, tar);
					}
					esNumero = false;
					while(!esNumero)
					{
						try
						{
							Console.Write(">> ");
							tarea = int.Parse(Console.ReadLine());
							if((tarea > listaTareas.Count) || (tarea < 1))
							{
								throw new Exception();
							}
							esNumero = true;
						}
						catch(FormatException)
						{
							Mensaje("red", "Solo puede ingresar números.");
						}
						catch(Exception)
						{
							Mensaje("red", "Ingrese un carácter válido.");
						}
					}
					cont = 1;
					foreach(string tar in listaTareas)
					{
						if(tar == "Ingresar manualmente")
				        {
							termina = false;
							while(!termina)
							{
								try
								{
									Console.Write("Ingresar manualmente >> ");
									tareaS = Console.ReadLine();
									if(tareaS.Length == 0)
									{
										throw new ArgumentNullException();
									}
									if(tareaS.Length > 18)
									{
										throw new ArgumentOutOfRangeException();
									}
									termina = true;
								}
								catch(ArgumentNullException)
								{
									Mensaje("red","No puede ingresar campos vacios.");
								}
								catch(ArgumentOutOfRangeException)
								{
									Mensaje("red", "Se permiten 18 caracteres máximo.");
								}
							}
							break;
				        }
						if(tarea == cont)
						{
							tareaS = tar;
							break;
						}
						cont++;
					}
				}
				esNumero = false;
				sueldo=0;
				while(!esNumero)
				{
					try
					{
						Console.Write("Sueldo por hora >> ");
						sueldoS = Console.ReadLine();
						if(sueldoS.Contains("."))
						{
							Mensaje("red", "Ingresar decimales con ',' no '.'");
						}
						else
						{
							sueldo = float.Parse(sueldoS);
							if(sueldo <= 0 || sueldo.ToString().Length > 10)
							{
								Mensaje("red", "Sueldo inválido.");
							}
							else
							{
								esNumero = true;
							}
						}
					}
					catch(FormatException)
					{
						Mensaje("red", "Solo puede ingresar números.");
					}
				}
				Console.Write("Datos Ingresados:\nNombre: {0}\nApellido: {1}\nDNI: {2}\nTarea: {3}\nSueldo por hora: {4}:\nConfirmar alta de empleado (S/n) >> ", nombre, apellido, documento, tareaS, sueldo.ToString());
				confirmar = Console.ReadLine();
				termina = false;
				while(!termina)
				{
					if(confirmar == "S" || confirmar == "s")
					{
						s.AltaEmpleado(nombre,apellido,documento.ToString(),tareaS,sueldo);
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("Alta de empleado registrada.");
						Console.ForegroundColor = ConsoleColor.White;
						termina = true;
						Console.ReadKey();
						AltaEmpleado(s);
						break;
					}
					else if(confirmar == "N" || confirmar == "n")
					{
						termina = true;
						AltaEmpleado(s);
						break;
					}
					else
					{
						Mensaje("red", "Ingrese un carácter válido.");
						Console.Write("Datos Ingresados:\nNombre: {0}\nApellido: {1}\nDNI: {2}\nTarea: {3}\nSueldo por hora: {4}:\nConfirmar alta de empleado (S/n) >> ", nombre, apellido, documento, tarea, sueldo.ToString());
						confirmar = Console.ReadLine();
					}
				}
				break;
			}
		}
		
		static void BajaEmpleado(Salon s)
		{	
			Empleado aux;
			bool esNumero, termina;
			int opcion;
			string confirmar;
			
			if(s.ListaEmpleados.Count == 0)
			{
				Mensaje("red", "No hay empleados registrados.");
				Console.WriteLine("Toque cualquier tecla para continuar...");
				Console.ReadKey();
			}
			else
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("Gestion de Baja de Empleado\n---------------------------");
				MostrarEmpleados("empleados", s.ListaEmpleados, s.ListaEncargados);
				esNumero = false;
				aux = null;
				opcion = -1;
				while(!esNumero)
				{
					try
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write("Seleccionar legajo o '0' para regresar al menú >> ");
						Console.ForegroundColor = ConsoleColor.White;
						opcion = int.Parse(Console.ReadLine());
						if(opcion == 0)
						{
							break;
						}
						if(opcion < 0)
						{
							throw new ArgumentOutOfRangeException();
						}
						foreach(Empleado emp in s.ListaEmpleados)
						{
							if(emp.Legajo == opcion)
							{
								aux = emp;
								break;
							}
						}
						if(aux == null)
						{
							throw new ArgumentOutOfRangeException();
						}
						esNumero = true;
					}
					catch (FormatException)
					{
						Mensaje("red", "Solo puede ingresar números.");
					}
					catch (ArgumentOutOfRangeException)
					{
						Mensaje("red", "Ingrese un carácter válido.");
					}
					catch(OverflowException)
					{
						Mensaje("red", "Cantidad de carácteres inválida.");
					}
				}
				while(opcion != 0)
				{
					Console.Write("Datos Ingresados:\nLegajo: {0}\nNombre: {1}\nApellido: {2}\nDNI: {3}\nTarea: {4}\nSueldo por hora: {5}:\nConfirmar baja de empleado (S/n) >> ", aux.Legajo, aux.Nombre, aux.Apellido, aux.DNI, aux.Tarea, aux.Sueldo);
					confirmar = Console.ReadLine();
					termina = false;
					while(!termina)
					{
						if(confirmar == "S" || confirmar == "s")
						{
							s.BajaEmpleado(aux);
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Baja de empleado registrada.");
							Console.ForegroundColor = ConsoleColor.White;
							termina = true;
							Console.ReadKey();
							BajaEmpleado(s);
						}
						else if(confirmar == "N" || confirmar == "n")
						{
							termina = true;
							BajaEmpleado(s);
						}
						else
						{
							Mensaje("red", "Ingrese un carácter válido.");
							Console.Write("Datos Ingresados:\nLegajo: {0}\nNombre: {1}\nApellido: {2}\nDNI: {3}\nTarea: {4}\nSueldo por hora: {5}:\nConfirmar baja de empleado (S/n) >> ", aux.Legajo, aux.Nombre, aux.Apellido, aux.DNI, aux.Tarea, aux.Sueldo);
							confirmar = Console.ReadLine();
						}
					}
					break;
				}
			}
		}
		
		static void AltaEncargado(Salon s)
		{
			Empleado aux;
			bool esNumero, esAumento, confirmar;
			int opcion;
			float aumento;
			string confirmarS;
			
			if(s.ListaEmpleados.Count == 0)
			{
				Mensaje("red", "No es posible continuar porque no hay empleados registrados.");
				Console.WriteLine("Toque cualquier tecla para regresar...");
				Console.ReadKey();
			}
			else
			{
				Console.Clear();
				Mensaje("cyan", "Gestion de Alta de Encargado\n----------------------------");
				MostrarEmpleados("empleados", s.ListaEmpleados, s.ListaEncargados);
				esNumero = false;
				opcion = -1;
				aux = null;
				while(!esNumero)
				{
					try
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write("Seleccionar legajo o '0' para regresar al menú >> ");
						Console.ForegroundColor = ConsoleColor.White;
						opcion = int.Parse(Console.ReadLine());
						if(opcion < 0)
						{
							throw new ArgumentOutOfRangeException();
						}
						if(opcion == 0)
						{
							break;
						}
						foreach(Empleado emp in s.ListaEmpleados)
						{
							if(opcion == emp.Legajo)
							{
								aux = emp;
								break;
							}
						}
						if(aux == null)
						{
							throw new ArgumentOutOfRangeException();
						}
						esNumero = true;
					}
					catch (FormatException)
					{
						Mensaje("red", "Solo puede ingresar números.");
					}
					catch (ArgumentOutOfRangeException)
					{
						Mensaje("red", "Ingrese un carácter válido.");
					}
					catch(OverflowException)
					{
						Mensaje("red", "Cantidad de carácteres inválida.");
					}
				}
				while(opcion != 0)
				{
					esAumento = false;
					aumento = -1;
					while(!esAumento)
					{
						try
						{
							Console.Write("Aumento de sueldo por hora >> ");
							aumento = float.Parse(Console.ReadLine());
							if(aumento <= 0)
							{
								throw new ArgumentOutOfRangeException();
							}
							esAumento = true;
						}
						catch(FormatException)
						{
							Mensaje("red", "Solo puede ingresar números.");
						}
						catch(ArgumentOutOfRangeException)
						{
							Mensaje("red", "El valor debe ser mayor a 0.");
						}
						catch(OverflowException)
						{
							Mensaje("red", "Cantidad de carácteres inválida.");
						}
					}
					confirmar = false;
					while(!confirmar)
					{
						Console.Write("Empleado seleccionado:\nLegajo: {0}\nNombre: {1}\nApellido: {2}\nDNI: {3}\nTarea: {4}\nSueldo por hora: {5}\nAumento: {6}\n¿Confirmar ascenso a encargado? (S/n) >> ", aux.Legajo, aux.Nombre, aux.Apellido, aux.DNI, aux.Tarea, aux.Sueldo, aumento);
						confirmarS = Console.ReadLine();
						if(confirmarS.ToLower() == "s")
						{
							s.AltaEncargado(aux, aumento);
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Alta de encargado registrada.");
							Console.ForegroundColor = ConsoleColor.White;
							confirmar = true;
							Console.ReadLine();
							AltaEncargado(s);
						}
						else if(confirmarS.ToLower() == "n")
						{
							confirmar = true;
							AltaEncargado(s);
						}
						else
						{
							Mensaje("red", "Ingrese una opción válida.");
							Console.Write(">> ");
							confirmarS = Console.ReadLine();
						}
					}
					break;
				}
			}
		}
		
		static void BajaEncargado(Salon s)
		{
			Encargado aux;
			bool esNumero, confirmar, enEjercicio;
			int opcion;
			string confirmarS;
			
			if(s.ListaEncargados.Count == 0)
			{
				Mensaje("red", "No es posible continuar porque no hay empleados registrados.");
				Console.WriteLine("Toque cualquier tecla para regresar...");
				Console.ReadKey();
			}
			else
			{
				Console.Clear();
				Mensaje("cyan", "Gestion de Baja de Encargado\n----------------------------");
				MostrarEmpleados("encargados", s.ListaEmpleados, s.ListaEncargados);
				esNumero = false;
				opcion = -1;
				aux = null;
				while(!esNumero)
				{
					try
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write("Seleccionar legajo o '0' para regresar al menú >> ");
						Console.ForegroundColor = ConsoleColor.White;
						opcion = int.Parse(Console.ReadLine());
						if(opcion == 0)
						{
							break;
						}
						if(opcion < 0)
						{
							throw new ArgumentOutOfRangeException();
						}
						foreach(Encargado enc in s.ListaEncargados)
						{
							if(opcion == enc.Legajo)
							{
								aux = enc;
								break;
							}
						}
						if(aux == null)
						{
							throw new ArgumentOutOfRangeException();
						}
						else
						{
							esNumero = true;
						}
					}
					catch (FormatException)
					{
						Mensaje("red", "Solo puede ingresar números.");
					}
					catch (ArgumentOutOfRangeException)
					{
						Mensaje("red", "Ingrese un carácter válido.");
					}
					catch(OverflowException)
					{
						Mensaje("red", "Cantidad de carácteres inválida.");
					}
				}
				while(opcion != 0)
				{
					enEjercicio = false;
					if(s.ListaEventos.Count > 0)
					{
						foreach(Evento elem in s.ListaEventos)
						{
							if(elem.EncargadoEvento == opcion)
							{
								enEjercicio = true;
							}
						}
					}
					if(enEjercicio == true)
					{
						Mensaje("red", "El encargado está asignado a un evento, no se puede proseguir con la acción.");
						Console.WriteLine("Toque cualquier tecla para continuar...");
						Console.ReadKey();
					}
					else
					{
						Console.WriteLine("Selección:\nLegajo: {0}\nNombre: {1}\nApellido: {2}\nDNI: {3}\nTarea: {4}\nSueldo por hora: {5}\n¿Confirmar baja de encargado? (S/T/n)", aux.Legajo, aux.Nombre, aux.Apellido, aux.DNI, aux.Tarea, aux.SueldoEncargado);
						Mensaje("yellow", "(Ingrese T para dar de baja por completo al empleado)");
						Console.Write(">> ");
						confirmarS = Console.ReadLine();
						confirmar = false;
						while(!confirmar)
						{
							if(confirmarS.ToLower() == "s")
							{
								s.BajaEncargado(aux, confirmarS);
								Console.ForegroundColor = ConsoleColor.Green;
								Console.WriteLine("Baja de encargado completa.");
								Console.ForegroundColor = ConsoleColor.White;
								confirmar = true;
								Console.ReadLine();
								BajaEncargado(s);
							}
							else if(confirmarS.ToLower() == "t")
							{
								s.BajaEncargado(aux, confirmarS);
								Console.ForegroundColor = ConsoleColor.Green;
								Console.WriteLine("Baja de encargado/empleado completa.");
								Console.ForegroundColor = ConsoleColor.White;
								confirmar = true;
								Console.ReadLine();
								BajaEncargado(s);
							}
							else if(confirmarS.ToLower() == "n")
							{
								confirmar = true;
								BajaEncargado(s);
							}
							else
							{
								Mensaje("red", "Ingrese una opción válida.");
								Console.Write(">> ");
								confirmarS = Console.ReadLine();
							}
						}
					}
					break;
				}
			}
		}
		
		static void AñadirReserva(Salon s, DateTime fechaActual)
		{
		    string tipoEvento, nombreCliente, confirmarReserva;
		    int dia, mes, anio, hora, dniCliente, opcionServicio, encargadoLeg, auxIdServicio;
			float costoTotal, seña;
			ArrayList serviciosSolicitados;
			DateTime fyh;
			bool esNumero, esValido, termina, confirmar;
			
			
			Console.Clear();
			
			if(s.ListaEncargados.Count == 0)
			{
				Mensaje("red", "No se puede continuar porque no hay encargados disponibles para el evento.");
				Console.WriteLine("Pulse cualquier tecla para continuar....");
				Console.ReadKey();
			}
			else if(s.ListaServicios.Count == 0)
			{
				Mensaje("red", "No se puede continuar porque no hay servicios disponibles que ofrecer.");
				Console.WriteLine("Pulse cualquier tecla para continuar....");
				Console.ReadKey();
			}
			else
			{
				Mensaje("cyan", "Añadir reserva\n--------------");
				esNumero = false;
				dia = -1; mes = -1; anio = -1; hora =-1;
				fyh = new DateTime(1,1,1,0,0,0);
				while(!esNumero)
				{
			        try
					{
			            Console.ForegroundColor= ConsoleColor.Yellow;
						Console.Write("Ingrese el día pertinente o '0' para regresar >> ");
						Console.ForegroundColor= ConsoleColor.White;
						dia = int.Parse(Console.ReadLine());
						if(dia != 0)
						{
							if((dia < 0) || (dia > 31))
							{
								throw new ArgumentOutOfRangeException();
							}
							else
							{
								esNumero= true;
							}
						}
						else
						{
			               	break;
			            }
			        }
					catch(FormatException)
					{
			            Mensaje("red", "Solo puede ingresar números.");
			        }
					catch(ArgumentOutOfRangeException)
					{
						Mensaje("red", "Ingrese un día válido.");
					}
					catch(OverflowException)
					{
						Mensaje("red", "Cantidad de carácteres inválida.");
					}
			    }
				while(dia != 0)
				{
					esNumero = false;
					while(!esNumero)
					{
				        try
						{
							Console.Write("Ingrese el mes >> ");
							mes = int.Parse(Console.ReadLine());
							if((mes == 0) || (mes > 12))
							{
								throw new ArgumentOutOfRangeException();
							}
							else if((dia > 29) && (mes == 2))
							{
								throw new FebreroNoPoseeMasDe29DiasException();
							}
							else
							{
								esNumero = true;
							}
				        }
						catch(FormatException)
						{
							Mensaje("red", "Solo puede ingresar números.");
				        }
						catch(ArgumentOutOfRangeException)
						{
							Mensaje("red", "No hay mes correspondiente.");
						}
						catch(FebreroNoPoseeMasDe29DiasException)
						{
							Mensaje("red", "Febrero no posee más de 28 o 29 días.");
						}
						catch(OverflowException)
						{
							Mensaje("red", "Cantidad de carácteres inválida.");
						}
				    }
					esNumero = false;
					while(!esNumero)
					{
				        try
						{
							Console.Write("Ingrese el año (Fechas disponibles hasta 2027) >> ");
							anio = int.Parse(Console.ReadLine());
							if((anio >= fechaActual.Year) && (anio <= 2027))
							{
								esNumero = true;
							}
							else
							{
								throw new ArgumentOutOfRangeException();
							}
				        }
						catch(FormatException)
						{
							Mensaje("red", "Solo puede ingresar números.");
				        }
						catch(ArgumentOutOfRangeException)
						{
							Mensaje("red", "Debe ingresar un año válido.");
						}
						catch(OverflowException)
						{
							Mensaje("red", "Cantidad de carácteres inválida.");
						}
				    }
					esNumero = false;
					while(!esNumero)
					{
				        try
						{
							Console.Write("Ingrese un horario entre las 10 y 22hrs. >> ");
							hora = int.Parse(Console.ReadLine());
							if((hora >= 10) && (hora <= 22))
							{
								esNumero = true;
							}
							else
							{
								throw new ArgumentOutOfRangeException();
							}
				        }
						catch(FormatException)
						{
							Mensaje("red", "Solo puede ingresar números.");
				        }
						catch(ArgumentOutOfRangeException)
						{
							Mensaje("red", "Solo se disponen horarios de 10 a.m a 22 p.m.");
						}
						catch(OverflowException)
						{
							Mensaje("red", "Cantidad de carácteres inválida.");
						}
				    }
					try
					{
						fyh = new DateTime(anio,mes,dia,hora,0,0);
						foreach(Evento elem in s.ListaEventos)
						{
							if(fyh == elem.FechayHora)
							{
								throw new FechaDeEventoNoDisponibleException();
							}
							if(fyh < fechaActual)
							{
								throw new ArgumentOutOfRangeException();
							}
						}
					}
					catch(FechaDeEventoNoDisponibleException)
					{
						Mensaje("red", "La fecha se encuentra en uso. Seleccione otra.");
						Console.WriteLine("Presione cualquier tecla para continuar...");
						Console.ReadKey();
						AñadirReserva(s, fechaActual);
						break;
					}
					catch(ArgumentOutOfRangeException)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("La fecha solicitada: {0} es inválida.", fyh);
						Console.ForegroundColor= ConsoleColor.White;
						Console.WriteLine("Presione cualquier tecla para continuar...");
						Console.ReadKey();
						AñadirReserva(s, fechaActual);
						break;
					}
					nombreCliente = null; tipoEvento = null; dniCliente = 0;
					esValido = false;
					while(!esValido)
					{
					    try
						{
					    	Console.Write("Ingrese el nombre y apellido del cliente >> ");
					        nombreCliente = Console.ReadLine();
							if(nombreCliente.Length == 0)
							{
					            throw new ArgumentNullException();
					        }
							esValido = true;
					    }
						catch(ArgumentNullException)
						{
							Mensaje("red","No puede ingresar campos vacios.");
					    }
					}
					esValido = false;
					while(!esValido)
					{
					    try
						{
							Console.Write("Ingrese el DNI del cliente >> ");
							dniCliente = int.Parse(Console.ReadLine());
							if(dniCliente.ToString().Length == 0)
							{
					            throw new ArgumentNullException();
					        }
							if((dniCliente.ToString().Length > 8) || (dniCliente.ToString().Length < 7))
							{
								throw new ArgumentOutOfRangeException();
							}
							esValido = true;
					    }
						catch(FormatException)
						{
							Mensaje("red","Solo puede ingresar números.");
					    }
						catch(ArgumentNullException)
						{
							Mensaje("red","No puede ingresar campos vacios.");
					    }
						catch(ArgumentOutOfRangeException)
						{
							Mensaje("red","Numero inválido.");
						}
						catch(OverflowException)
						{
							Mensaje("red","Cantidad de carácteres inválida.");
						}
					}
					esValido = false;
					while(!esValido)
					{
					    try
						{
							Console.Write("Ingrese el tipo de evento >> ");
							tipoEvento = Console.ReadLine();
							if(tipoEvento.Length == 0)
							{
					            throw new ArgumentNullException();
					        }
							esValido = true;
						
					    }
						catch(FormatException)
						{
							Mensaje("red","Caracteres inválidos.");
					    }
						catch(ArgumentNullException)
						{
							Mensaje("red","No puede ingresar campos vacios.");
						}
					}
					serviciosSolicitados = new ArrayList();
					termina = false;
					MostrarServicios(s.ListaServicios);
					while(!termina)
					{
					    try
						{
					    	Console.Write("Seleccione 0 para terminar. >> ");
							opcionServicio = int.Parse(Console.ReadLine());
							if(opcionServicio.ToString().Length == 0)
							{
					            throw new ArgumentNullException();
					        }
							else if((opcionServicio == 0) && (serviciosSolicitados.Count == 0))
							{
					            throw new NullReferenceException();
					        }
							else if(opcionServicio > 0)
							{
								if(opcionServicio > s.ListaServicios.Count)
								{
									throw new IndexOutOfRangeException();
								}
								else
								{
									foreach(Servicio elem in s.ListaServicios)
									{
						                if(elem.IdServicio == opcionServicio)
										{
						                    auxIdServicio = elem.IdServicio;
						                    serviciosSolicitados.Add(auxIdServicio);
						                }
									}
					            }
					        }
							else if((opcionServicio == 0) && (serviciosSolicitados.Count > 0))
							{
					            termina = true;
					        }
					    }
					    catch(FormatException)
						{
					    	Mensaje("red","Solo puede ingresar números.");
					    }
						catch(NullReferenceException)
						{
							Mensaje("red","Debe seleccionar al menos 1 servicio.");
					    }
						catch(ArgumentNullException)
						{
							Mensaje("red","No puede ingresar un campo vacío.");
					    }
						catch(IndexOutOfRangeException)
						{
							Mensaje("red","Debe ingresar una opcion válida.");
					    }
						catch(OverflowException)
						{
							Mensaje("red","Cantidad de carácteres inválida.");
						}
					}
					esValido = false;
					encargadoLeg = -1;
					Console.WriteLine("Asignar encargado");
					MostrarEmpleados("encargados", s.ListaEmpleados, s.ListaEncargados);
					while(!esValido)
					{
					    try
						{
					    	Console.Write(">> ");
					        encargadoLeg = int.Parse(Console.ReadLine());
							if(encargadoLeg < 1)
							{
					            throw new ArgumentOutOfRangeException();
					        }
							foreach(Encargado elem in s.ListaEncargados)
							{
								if(elem.Legajo == encargadoLeg)
								{
									esValido = true;
								}
							}
					    }
						catch(FormatException)
						{
							Mensaje("red","Solo puede ingresar números.");
					    }
						catch(ArgumentOutOfRangeException)
						{
							Mensaje("red","Debe ingresar una opcion válida.");
						}
						catch(OverflowException)
						{
							Mensaje("red","Cantidad de carácteres inválida.");
						}
					}
					Console.WriteLine("Datos ingresados:\nNombre del cliente: {0}\nDNI del cliente: {1}\nFecha y hora del evento: {2}\nTipo de evento: {3}\nEncargado: {4}\nLista de servicios solicitados: ", nombreCliente, dniCliente, fyh.ToString(), tipoEvento, encargadoLeg);
					costoTotal = 0;
					foreach(int elem in serviciosSolicitados)
					{
						foreach(Servicio elemServ in s.ListaServicios)
						{
							if(elem == elemServ.IdServicio)
							{
								Console.Write("{0}.\t{1}\n", elemServ.IdServicio, elemServ.Nombre);
								costoTotal += elemServ.Costo;
							}
						}
					}
					seña = costoTotal / 2;
					Console.WriteLine("Costo del evento: {0}\nSeña: {1}", costoTotal, seña);
					confirmar = false;
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write("¿Confirmar Reserva? (S/n) >> ");
					Console.ForegroundColor = ConsoleColor.White;
					confirmarReserva = Console.ReadLine();
					while(!confirmar)
					{
						if(confirmarReserva.ToLower() == "s")
						{
							s.AñadirReservaEvento(nombreCliente, dniCliente.ToString(), tipoEvento, encargadoLeg, fyh, serviciosSolicitados, costoTotal, seña);
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Reserva añadida al sistema.");
							Console.ForegroundColor = ConsoleColor.White;
							confirmar = true;
							Console.ReadKey();
							AñadirReserva(s, fechaActual);
						}
						else if(confirmarReserva.ToLower() == "n")
						{
							confirmar = true;
							AñadirReserva(s, fechaActual);
						}
						else
						{
							Mensaje("red","Debe ingresar una opcion válida.");
							Console.Write(">> ");
							confirmarReserva = Console.ReadLine();
						}
					}
			        break;
			    }
			}
		}
		
		static void CancelarEvento(Salon s, DateTime fechaActual)
		{
			string confirmar;
			int opcionEvento;
			bool esNumero,termina;
			Evento aux;
			
			Console.Clear();
			
			if(s.ListaEventos.Count > 0)
			{
				Mensaje("cyan","Cancelar evento\n--------------");
				foreach(Evento elem in s.ListaEventos)
				{
					Console.WriteLine("{0} | {1} | {2} | {3} | {4}", elem.IdEvento, elem.ClienteNombre, elem.ClienteDNI, elem.TipoEvento, elem.FechayHora);
				}
				esNumero = false;
				opcionEvento = -1;
				while(!esNumero)
				{
					try
					{
						Console.Write("Seleccione el evento que desea eliminar ('0' para regresar) >> ");
						opcionEvento = int.Parse(Console.ReadLine());
						if(opcionEvento < 0)
						{
							throw new IndexOutOfRangeException();
						}
						if(opcionEvento == 0)
						{
							break;
						}
						esNumero = true;
					}
					catch(FormatException)
					{
						Mensaje("red","Solo pueden ingresarse números.");
					}
					catch(IndexOutOfRangeException)
					{
						Mensaje("red","Ingrese una opcion válida.");
					}
					catch(OverflowException)
					{
						Mensaje("red","Cantidad de carácteres inválida.");
					}
				}
				while(opcionEvento != 0)
				{
					aux = null;
					foreach(Evento elem in s.ListaEventos)
					{
						if(opcionEvento == elem.IdEvento)
						{
							aux = elem;
							break;
						}
					}
					if(aux == null)
					{
						break;
					}
					termina = false;
					Console.Write("Datos seleccionados:\nNombre del Cliente: {0}\nDNI: {1}\nTipo de evento: {2}\nFecha del evento: {3}\n¿Confirmar cancelación de evento? (S/n) >> ", aux.ClienteNombre, aux.ClienteDNI, aux.TipoEvento, aux.FechayHora);
					confirmar = Console.ReadLine();
					while(!termina)
					{
						if(confirmar.ToLower() =="s")
						{
							TimeSpan fechaAux = aux.FechayHora - fechaActual;
							if(fechaAux.Days>= 30)
							{
								Console.ForegroundColor = ConsoleColor.Green;
								Console.WriteLine("Dado que la cancelación transcurrió {0} días antes del evento, se devolverá la seña.", fechaAux.Days);
								Console.ForegroundColor = ConsoleColor.White;
							}
							else
							{
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("Dado que la cancelación sucedió {0} días antes del evento, no será devuelta la seña.", fechaAux.Days);
								Console.ForegroundColor = ConsoleColor.White;
							}
							s.CancelarReservaEvento(aux);
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Reserva cancelada.");
							Console.ForegroundColor = ConsoleColor.White;
							termina = true;
							Console.WriteLine("Toque cualquier tecla para continuar...");
							Console.ReadKey();
							CancelarEvento(s, fechaActual);
						}
						else if(confirmar.ToLower() == "n")
						{
							termina = true;
							Console.WriteLine("Toque cualquier tecla para continuar...");
							CancelarEvento(s, fechaActual);
						}
						else
						{
							Mensaje("red","Ingrese una opcion válida.");
							Console.Write(">> ");
							confirmar = Console.ReadLine();
						}
					}
					break;
				}
			}
			else
			{
				Mensaje("red","No hay eventos registrados.");
				Console.WriteLine("Toque cualquier tecla para continuar...");
				Console.ReadKey();
			}
		}
		
		static void MostrarEmpleados(string tipo, ArrayList datosEmpleado, ArrayList datosEncargado)
		{
			string sep;
				
			sep = "-";
			
			if(((tipo == "mixto") && ((datosEmpleado.Count > 0) || (datosEncargado.Count > 0))) || ((tipo == "empleados") && (datosEmpleado.Count > 0)) || ((tipo == "encargados") && (datosEncargado.Count > 0)))
			{
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("Legajo | Nombre | Apellido | DNI | Tarea | Sueldo/Hora");
				Console.WriteLine(sep.PadRight(54,'-'));
				Console.ForegroundColor = ConsoleColor.White;
				if(tipo == "mixto")
				{
					foreach(Empleado elem in datosEmpleado)
					{
						Console.WriteLine("{0} | {1} | {2} | {3} | {4} | ${5}", elem.Legajo, elem.Nombre, elem.Apellido,elem.DNI, elem.Tarea, elem.Sueldo);
						Console.WriteLine(sep.PadRight(54,'-'));
					}
					foreach(Encargado elem in datosEncargado)
					{
						Console.WriteLine("{0} | {1} | {2} | {3} | {4} | ${5}", elem.Legajo, elem.Nombre, elem.Apellido,elem.DNI, elem.Tarea, elem.SueldoEncargado);
						Console.WriteLine(sep.PadRight(54,'-'));
					}
				}
				else if(tipo == "empleados")
				{
					foreach(Empleado elem in datosEmpleado)
					{
						Console.WriteLine("{0} | {1} | {2} | {3} | {4} | ${5}", elem.Legajo, elem.Nombre, elem.Apellido,elem.DNI, elem.Tarea, elem.Sueldo);
						Console.WriteLine(sep.PadRight(54,'-'));
					}
				}
				else if(tipo == "encargados")
				{
					foreach(Encargado elem in datosEncargado)
					{
						Console.WriteLine("{0} | {1} | {2} | {3} | {4} | ${5}", elem.Legajo, elem.Nombre, elem.Apellido,elem.DNI, elem.Tarea, elem.SueldoEncargado);
						Console.WriteLine(sep.PadRight(54,'-'));
					}
				}
				Console.WriteLine("Continuar...");
			}
			else
			{
				Mensaje("red", "No hay empleados registrados.");
				Console.WriteLine("Toque cualquier tecla para continuar...");
			}
		}
		
		static void MostrarServicios(ArrayList datos)
		{
			if(datos.Count > 0)
			{
				Console.WriteLine();
				Mensaje("cyan", "Id | Nombre | Descripcion | Costo");
				foreach(Servicio elem in datos)
				{
					Console.WriteLine("{0} | {1} | {2} | {3}", elem.IdServicio, elem.Nombre, elem.Descripcion, elem.Costo);
				}
				Console.WriteLine();
			}
			else
			{
				Mensaje("red","No hay servicios registrados.");
				Console.WriteLine("Toque cualquier tecla para continuar...");
			}
		}
		
		static void MostrarEventos(ArrayList listaEventos, ArrayList listaServicios)
		{
			string titulo, sep;
				
			sep = "-";
			
			if(listaEventos.Count > 0)
			{
				Console.WriteLine();
				titulo = "Información de Evento";
				foreach(Evento elem in listaEventos)
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine(sep.PadRight(120,'-'));
					Console.WriteLine(titulo.PadLeft((120/2)+(titulo.Length/2), ' '));
					Console.WriteLine(sep.PadRight(120,'-'));
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("ID: {0} | Cliente: {1} | DNI: {2} | Tipo de Evento: {3} | {4} | Encargado: {5}", elem.IdEvento, elem.ClienteNombre, elem.ClienteDNI, elem.TipoEvento, elem.FechayHora, elem.EncargadoEvento);
					Console.WriteLine(sep.PadRight(120,'-'));
					Console.WriteLine("Lista de servicios solicitados:");
					foreach(Servicio servicio in listaServicios)
					{
						foreach(int id in elem.ServiciosContratados)
						{
							if(servicio.IdServicio == id)
							{
								Console.WriteLine("{0} | {1} | {2} | {3}", servicio.IdServicio, servicio.Nombre, servicio.Descripcion, servicio.Costo);
							}
						}
					}
					Console.WriteLine(sep.PadRight(120,'-'));
					Console.WriteLine("Costo Total: {0} | Seña: {1}",elem.CostoTotal, elem.SeñaEvento);
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine(sep.PadRight(120,'-'));
					Console.ForegroundColor = ConsoleColor.White;
				}
				Console.WriteLine();
			}
			else
			{
				Mensaje("red", "No hay eventos registrados.");
				Console.WriteLine("Toque cualquier tecla para continuar...");
			}
			Console.ReadKey();
		}
		
		static void Mensaje(string color, string texto)
		{
			if(color=="red")
			{
				Console.ForegroundColor = ConsoleColor.Red;
			}
			else if(color=="cyan")
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
			}
			else if(color == "yellow")
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			Console.WriteLine(texto);
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
	
	public class FechaDeEventoNoDisponibleException:Exception{};
	public class FebreroNoPoseeMasDe29DiasException:Exception{};
}