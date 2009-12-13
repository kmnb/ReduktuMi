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
using Gtk;

namespace ReduktuMi.Views
{
	public partial class MainWindow : Gtk.Window
	{
		FileChooserDialog imagesChooser;
		Controlers.Controler controler;
		
		public MainWindow() : base(WindowType.Toplevel)
		{
			this.controler = new ReduktuMi.Controlers.Controler();
			this.Build();
			// Colonne image
			TreeViewColumn imageColumn = new TreeViewColumn();
			CellRendererPixbuf imageCell = new CellRendererPixbuf();
			imageColumn.PackStart(imageCell, true);
			// Colonne Nom
			TreeViewColumn nameColumn = new TreeViewColumn();
			nameColumn.Title = "Name";
			CellRendererText nameCell = new CellRendererText();
			nameColumn.PackStart(nameCell, true);
			// Colonne Full Path
			TreeViewColumn pathColumn = new TreeViewColumn();
			pathColumn.Title = "Path";
			CellRendererText pathCell = new CellRendererText();
			pathColumn.PackStart (pathCell, false);
			// Add columns
			this.treeViewImages.AppendColumn(imageColumn);
			this.treeViewImages.AppendColumn(nameColumn);
			this.treeViewImages.AppendColumn(pathColumn);
			// Assign the model
			this.treeViewImages.Model = this.controler.ImagesModel;
		}

		protected virtual void OnBtnRemoveClicked(object sender, System.EventArgs e)
		{
			TreePath[] treePaths = treeViewImages.Selection.GetSelectedRows();
			this.controler.removeImages(treePaths);
		}

		protected virtual void OnBtnAddClicked (object sender, System.EventArgs e)
		{
			this.imagesChooser = new FileChooserDialog("Choose your images", this,
                       									FileChooserAction.Open, 
			                                           	"Cancel",ResponseType.Cancel,
                    									"Open",ResponseType.Accept);
			
			if(imagesChooser.Run() == (int)ResponseType.Accept)
			{
				string[] filesnames = this.imagesChooser.Filenames;
				this.controler.addImages(filesnames);
			}
			imagesChooser.Destroy();
		}
	}
}