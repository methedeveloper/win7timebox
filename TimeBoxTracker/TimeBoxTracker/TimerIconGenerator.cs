/*
 * Created by SharpDevelop.
 * User: joseantonio
 * Date: 10/05/2015
 * Time: 11:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace TimeBoxTracker
{
	/// <summary>
	/// Description of IconGenerator.
	/// </summary>
	public static class TimerIconGenerator
	{
		private static Icon lastIcon = null;
		
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool DestroyIcon(IntPtr hIcon);
		
		public static Icon Create(TimeSpan remainingTime)
		{
    		using (Bitmap bitmap = new Bitmap(32, 32))
    		{
    			using (Graphics graphics = Graphics.FromImage(bitmap))
    			{
					using (Font drawFont = new Font("Arial", 16, FontStyle.Bold))
					{
						using (SolidBrush drawBrush = new SolidBrush(Color.Black))
						{
							graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
							StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
							graphics.DrawString(remainingTime.Minutes.ToString(), drawFont, drawBrush, 16, 16, sf);
							graphics.DrawArc(new Pen(Color.Black, 2), 1,1,29,29,270,remainingTime.Seconds*6);
							Icon newIcon = Icon.FromHandle(bitmap.GetHicon());
							if (lastIcon != null)
							{
								DestroyIcon(lastIcon.Handle);
							}
							lastIcon = newIcon;
							return newIcon;
						}
					}
    		}
    	}
		}
	}
}
