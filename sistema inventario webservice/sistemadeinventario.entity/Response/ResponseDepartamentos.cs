﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemadeinventario.entity.Response
{
    public class ResponseDepartamentos
    {
        public int row { get; set; }
        public int iddepart { get; set; }
        public string depart { get; set; }
        public int status { get; set; }

        public string response { get; set; }
    }
}
