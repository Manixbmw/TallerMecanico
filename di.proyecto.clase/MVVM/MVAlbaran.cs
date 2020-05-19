﻿using di.proyecto.clase.Modelo;
using di.proyecto.clase.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace di.proyecto.clase.MVVM
{
    public class MVAlbaran : MVBase
    {
        private tallerEntities tallerEnt;
        private AlbaranServicio albServ;

        private ListCollectionView listaAlba;

        public MVAlbaran(tallerEntities ent)
        {
            tallerEnt = ent;
            albServ = new AlbaranServicio(tallerEnt);
            listaAlba = new ListCollectionView(albServ.getAll().ToList());

        }
        public ListCollectionView listaAlbaranes { get { return listaAlba; } }

    }
}
