﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tools.Pagination;

public class BasePageableModel
{
    public int Size { get; set; }
    public int Index { get; set; }
    public int Count { get; set; }
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }
}
