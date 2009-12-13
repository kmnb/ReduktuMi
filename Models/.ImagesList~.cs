using System;
using Gtk;

namespace ReduktuMi.Models
{
	

	public class ImagesModel : ListStore
	{		
		public ImagesModel() : base(typeof(Gdk.Pixbuf), typeof(string), typeof(string))
		{
		}
		
		public void addImage(string[] fullPaths)
		{
			foreach(string fullPath in fullPaths)
			{
				this.miniPix = new Gdk.Pixbuf(fullPath, 50, 50, true);
				string imageName = System.IO.Path.GetFileName(fullPath);
				
				this.imagesListStore.AppendValues(this.miniPix, imageName, fullPath);
			}
		}
		
		public void removeImages(TreePath[] treePaths)
		{
			foreach(TreePath treePath in treePaths)
			{
				this.imagesListStore.GetIter(out this.iter, treePath);
				this.imagesListStore.Remove(ref this.iter);
			}
		}
		
		public ListStore Model{
			get{ return this.imagesListStore;}
		}
	}
}
