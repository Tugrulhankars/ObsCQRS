using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tools.Constants;

public static class ActivitySourceProvider
{
    public static readonly ActivitySource Source = new ActivitySource("ActivitySource.Obs");
}
