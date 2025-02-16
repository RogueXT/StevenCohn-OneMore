﻿//************************************************************************************************
// Copyright © 2020 Steven M. Cohn. All Rights Reserved.
//************************************************************************************************

namespace River.OneMoreAddIn.Settings
{
	using River.OneMoreAddIn.UI;
	using System.Windows.Forms;


	/// <summary>
	/// Provides base capabilities for SettingsDialog UI sheets.
	/// </summary>
	/// <remarks>
	/// Preferred this to be abstract but that screws up VS Designer
	/// </remarks>
	internal class SheetBase : UserControl
	{
		protected readonly SettingsProvider provider;


		protected SheetBase()
		{
			// required for VS Designer
		}


		protected SheetBase(SettingsProvider provider)
		{
			SuspendLayout();
			BackColor = System.Drawing.SystemColors.ControlLightLight;
			Name = "SheetBase";
			Size = new System.Drawing.Size(800, 500);
			Dock = DockStyle.Fill;
			ResumeLayout(false);

			this.provider = provider;
		}


		/// <summary>
		/// The localized title to display in the header line of the settings dialog
		/// </summary>
		public string Title { get; set; }


		/// <summary>
		/// Collects the settings for the current sheet. The SettingsDialog calls this when
		/// the user clicks OK for each sheet and then saves the settings. This method gives
		/// the sheet the opportunity to add settings to the provider before they are saved.
		/// </summary>
		/// <returns></returns>
		public virtual bool CollectSettings() { return false; }


		/// <summary>
		/// Localizes each of the named controls by looking up the appropriate resource string
		/// </summary>
		/// <param name="keys">An collection of strings specifying the control names</param>
		protected void Localize(string[] keys)
		{
			TranslationHelper.Localize(this, keys);
		}


		/// <summary>
		/// Determines if the sheet needs to be localized
		/// </summary>
		/// <returns>True if the sheets needs to be localized; language is not default 'en'</returns>
		protected static bool NeedsLocalizing()
		{
			return AddIn.Culture.TwoLetterISOLanguageName != "en";
		}
	}
}
