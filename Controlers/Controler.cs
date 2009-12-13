using System;
using Gtk;

namespace ReduktuMi.Controlers
{
	
	public class Controler
	{
		Models.ImagesModel imagesModel;
		Gdk.Pixbuf miniPix;
		TreeIter iter;
		
		public Controler ()
		{
			this.imagesModel = new ReduktuMi.Models.ImagesModel();
		}
		
		public void addImages(string[] fullPaths)
		{
			foreach(string fullPath in fullPaths)
			{
				this.miniPix = new Gdk.Pixbuf(fullPath, 50, 50, true);
				string imageName = System.IO.Path.GetFileName(fullPath);
				
				this.imagesModel.AppendValues(this.miniPix, imageName, fullPath);
				this.imagesModel.GetIterFirst(out this.iter);
				System.Console.WriteLine("First element of second column in the model : "+
				                         this.imagesModel.GetValue(this.iter, 1).ToString());
			}
		}
		
		public void removeImages(TreePath[] treePaths)
		{
			foreach(TreePath treePath in treePaths)
			{
				this.imagesModel.GetIter(out this.iter, treePath);
				this.imagesModel.Remove(ref this.iter);
			}
		}
		
		public Models.ImagesModel ImagesModel{
			get{ return this.imagesModel; }
		}
	}
}
