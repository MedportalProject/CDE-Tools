/// THIS FILE IS PART OF CDE TOOLS PROJECT 
/// CDE TOOLS, A TERM SEARCH AND ANNOTATION EXCEL-ADDIN.
///
/// THIS PROGRAM IS FREE SOFTWARE, IS LICENSED UNDER APACHE LICENSE V2.0
/// Copyright 2020 Institute of Basic Medical Sciences, Chinese Academy of Medical Sciences
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///    http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
/// 
/// IN THIS PROGRAM WE USED OTHER OPEN SOURCE PROGRAM AND NCBO BIOPORTAL SERVER REST API:
/// BIOPORTAL REST-API: http://data.bioontology.org/documentation 
/// Based partially an example by ncbo in github project ncbo/ncbo_rest_sample_code[1]:
///    [1]https://github.com/ncbo/ncbo_rest_sample_code
/// ExcelDNA: zLib license, Copyright (C) 2005-2020 Govert van Drimmelen
/// Newtonsoft.Json: The MIT License (MIT), Copyright (c) 2007 James Newton-King
/// npoi: Apache License Version 2.0
/// SEE FILE LICENSE IN LICENSE FOLDER
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDETools.Entity.OLSDataTypes
{
    public class OLSDoc
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("iri")]
        public string IRI { get; set; }
        [JsonProperty("short_form")]
        public string Short_form { get; set; }
        [JsonProperty("obo_id")]
        public string Obo_id { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("ontology_name")]
        public string Ontology_name { get; set; }
        [JsonProperty("ontology_prefix")]
        public string Ontology_prefix { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("is_defining_ontology")]
        public string Is_defining_ontology { get; set; }
    }
}
