﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumasUnah.BL
{
    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
            {
                var nuevoUsuario = new Usuario();
                nuevoUsuario.Nombre = "marc";
                nuevoUsuario.Contraseña = Encriptar.CodificarContraseña("321");

                contexto.Usuarios.Add(nuevoUsuario);

                base.Seed(contexto);
            }
        }
    }

