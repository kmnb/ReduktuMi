/*
 * Copyright (C) 2009 Boris Lassort <http://www.boris.lassort.fr/>
 * 
 * This file is part of ReduktuMi.
 * 
 * ReduktuMi is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * ReduktuMi is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with ReduktuMi. If not, see <http://www.gnu.org/licenses/>.
 */

using System;

namespace ReduktuMi.Models
{
	
	public class ImagesModel : Gtk.ListStore
	{		
		public ImagesModel() : base(typeof(Gdk.Pixbuf), typeof(string), typeof(string))
		{
		}
	}
}
