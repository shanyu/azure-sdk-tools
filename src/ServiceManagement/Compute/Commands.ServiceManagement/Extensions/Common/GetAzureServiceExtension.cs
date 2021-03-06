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
    using System.Linq;
    using System.Management.Automation;
    using Management.Compute;
    using Model.PersistentVMModel;

    /// <summary>
    /// Get Windows Azure Service Extension.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureServiceExtension"), OutputType(typeof(ExtensionContext))]
    public class GetAzureServiceExtensionCommand : BaseAzureServiceExtensionCmdlet
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, HelpMessage = "Service Name")]
        public override string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, HelpMessage = "Deployment Slot: Production (default) or Staging")]
        [ValidateSet(DeploymentSlotType.Production, DeploymentSlotType.Staging, IgnoreCase = true)]
        public override string Slot
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Extension Name")]
        [ValidateNotNullOrEmptyAttribute]
        public override string ExtensionName
        {
            get;
            set;
        }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Extension Provider Namespace")]
        [ValidateNotNullOrEmptyAttribute]
        public override string ProviderNamespace
        {
            get;
            set;
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            ValidateService();
            ValidateDeployment();
        }

        public void ExecuteCommand()
        {
            ValidateParameters();
            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.HostedServices.ListExtensions(this.ServiceName),
                (s, r) =>
                {
                    var extensionRoleList = (from dr in Deployment.Roles
                                             select new ExtensionRole(dr.RoleName)).ToList().Union(new ExtensionRole[] { new ExtensionRole() });

                    return from role in extensionRoleList
                           from extension in r.Extensions
                           where ExtensionManager.GetBuilder(Deployment.ExtensionConfiguration).Exist(role, extension.Id)
                           select new ExtensionContext
                           {
                               OperationId = s.Id,
                               OperationDescription = CommandRuntime.ToString(),
                               OperationStatus = s.Status.ToString(),
                               Extension = extension.Type,
                               ProviderNameSpace = extension.ProviderNamespace,
                               Id = extension.Id,
                               Role = role,
                               PublicConfiguration = extension.PublicConfiguration
                           };
                });
        }

        protected override void OnProcessRecord()
        {
            ExecuteCommand();
        }
    }
}
