﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lski.Txt.Transformations {

	/// <summary>
	/// Only returns numeric values in the string
	/// </summary>
	public class NumericsOnly : Transformation {

		public override string Process(string value) {
			return Regex.Replace(value, @"[^\d]", "");
		}

		public override object Clone() {

			return new NumericsOnly();
		}

	}
}
