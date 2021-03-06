﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    using System.Management.Automation;
    using Model.PersistentVMModel;
    using Utilities.Common;

    /// <summary>
    /// Remove Windows Azure Service Extension.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureServiceExtension", DefaultParameterSetName = "RemoveByRoles"), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzureServiceExtensionCommand : BaseAzureServiceExtensionCmdlet
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = "RemoveByRoles", HelpMessage = "Cloud Service Name")]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = "RemoveAll", HelpMessage = "Cloud Service Name")]
        public override string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = "RemoveByRoles", HelpMessage = "Deployment Slot: Production (default) or Staging.")]
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = "RemoveAll", HelpMessage = "Deployment Slot: Production (default) or Staging.")]
        [ValidateSet(DeploymentSlotType.Production, DeploymentSlotType.Staging, IgnoreCase = true)]
        public override string Slot
        {
            get;
            set;
        }

        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = "RemoveByRoles", HelpMessage = "Default All Roles, or specify ones for Named Roles.")]
        public override string[] Role
        {
            get;
            set;
        }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "RemoveByRoles", HelpMessage = "Extension Name")]
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "RemoveAll", HelpMessage = "Extension Name")]
        [ValidateNotNullOrEmptyAttribute]
        public override string ExtensionName
        {
            get;
            set;
        }

        [Parameter(Position = 4, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "RemoveByRoles", HelpMessage = "Extension Provider Namespace")]
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "RemoveAll", HelpMessage = "Extension Provider Namespace")]
        [ValidateNotNullOrEmptyAttribute]
        public override string ProviderNamespace
        {
            get;
            set;
        }

        [Parameter(Position = 4, Mandatory = true, ParameterSetName = "RemoveAll", HelpMessage = "If specified uninstall all Diagnostics configurations from the cloud service.")]
        public override SwitchParameter UninstallConfiguration
        {
            get;
            set;
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            ValidateService();
            ValidateDeployment();
            ValidateRoles();
        }

        public void ExecuteCommand()
        {
            ValidateParameters();
            RemoveExtension();
        }

        protected override void OnProcessRecord()
        {
            ExecuteCommand();
        }
    }
}
