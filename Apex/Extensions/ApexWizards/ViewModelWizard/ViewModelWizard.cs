﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;

namespace ApexWizards.ViewModelWizard
{

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ViewModelWizard : IWizard
    {
        public void BeforeOpeningFile(EnvDTE.ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(EnvDTE.Project project)
        {
        }

        public void ProjectItemFinishedGenerating(EnvDTE.ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            try
            {
                //  Create the wizard view.
                ViewModelWizardView view = new ViewModelWizardView();

                //  Set the view model name.
                string viewModelName = string.Empty;
                replacementsDictionary.TryGetValue("$safeitemrootname$", out viewModelName);
                view.ViewModel.ViewModelName = viewModelName;

                //  Show the view.
                view.ShowDialog();
                
                //  Update the custom parameters.
                replacementsDictionary.Add("$ViewModelType$", view.ViewModel.CreateExampleNotifyingProperty ? "1" : "0");
                replacementsDictionary.Add("$CreateExampleObservableCollection$", view.ViewModel.CreateExampleObservableCollection ? "1" : "0");
                replacementsDictionary.Add("$CreateExampleCommand$", view.ViewModel.CreateExampleCommand ? "1" : "0");
            }
            catch (Exception ex)
            {
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}