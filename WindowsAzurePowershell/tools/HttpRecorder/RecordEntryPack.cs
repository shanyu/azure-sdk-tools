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

using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAzure.Utilities.HttpRecorder
{
    public class RecordEntryPack
    {
        private const int MaxEntriesCount = 100;
        public List<RecordEntry> Entries { get; set; }
        public Dictionary<string, Queue<string>> Names { get; set; }

        public RecordEntryPack()
        {
            Entries = new List<RecordEntry>();
        }

        public static RecordEntryPack Deserialize(string path)
        {
            return Utilities.DeserializeJson<RecordEntryPack>(path);
        }

        public void Serialize(string path)
        {
            if (Entries.Count > MaxEntriesCount)
            {
                Entries.RemoveRange(0, Entries.Count - MaxEntriesCount);
            }

            Utilities.SerializeJson(this, path);
        }
    }
}
