using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterScripter.DAL.Models;

namespace MasterScripter.DAL.Utils
{
    public static class FakeData
    {
        private static List<Tuple<double, double, string>> GetPoints()
        {
            //latitude	longitude	name
            return new List<Tuple<double, double, string>>()
            {
                new Tuple<double, double, string>(42.546245, 1.601554, "Andorra"),
                new Tuple<double, double, string>(23.424076, 53.847818, "United Arab Emirates"),
                new Tuple<double, double, string>(33.93911, 67.709953, "Afghanistan"),
                new Tuple<double, double, string>(17.060816, -61.796428, "Antigua and Barbuda"),
                new Tuple<double, double, string>(18.220554, -63.068615, "Anguilla"),
                new Tuple<double, double, string>(41.153332, 20.168331, "Albania"),
                new Tuple<double, double, string>(40.069099, 45.038189, "Armenia"),
                new Tuple<double, double, string>(12.226079, -69.060087, "Netherlands Antilles"),
                new Tuple<double, double, string>(-11.202692, 17.873887, "Angola"),
                new Tuple<double, double, string>(-75.250973, -0.071389, "Antarctica"),
                new Tuple<double, double, string>(-38.416097, -63.616672, "Argentina"),
                new Tuple<double, double, string>(-14.270972, -170.132217, "American Samoa"),
                new Tuple<double, double, string>(47.516231, 14.550072, "Austria"),
                new Tuple<double, double, string>(-25.274398, 133.775136, "Australia"),
                new Tuple<double, double, string>(12.52111, -69.968338, "Aruba"),
                new Tuple<double, double, string>(40.143105, 47.576927, "Azerbaijan"),
                new Tuple<double, double, string>(43.915886, 17.679076, "Bosnia and Herzegovina"),
                new Tuple<double, double, string>(13.193887, -59.543198, "Barbados"),
                new Tuple<double, double, string>(23.684994, 90.356331, "Bangladesh"),
                new Tuple<double, double, string>(50.503887, 4.469936, "Belgium"),
                new Tuple<double, double, string>(12.238333, -1.561593, "Burkina Faso"),
                new Tuple<double, double, string>(42.733883, 25.48583, "Bulgaria"),
                new Tuple<double, double, string>(25.930414, 50.637772, "Bahrain"),
                new Tuple<double, double, string>(-3.373056, 29.918886, "Burundi"),
                new Tuple<double, double, string>(9.30769, 2.315834, "Benin"),
                new Tuple<double, double, string>(32.321384, -64.75737, "Bermuda"),
                new Tuple<double, double, string>(4.535277, 114.727669, "Brunei"),
                new Tuple<double, double, string>(-16.290154, -63.588653, "Bolivia"),
                new Tuple<double, double, string>(-14.235004, -51.92528, "Brazil"),
                new Tuple<double, double, string>(25.03428, -77.39628, "Bahamas"),
                new Tuple<double, double, string>(27.514162, 90.433601, "Bhutan"),
                new Tuple<double, double, string>(-54.423199, 3.413194, "	Bouvet Island"),
                new Tuple<double, double, string>(-22.328474, 24.684866, "Botswana"),
                new Tuple<double, double, string>(53.709807, 27.953389, "Belarus"),
                new Tuple<double, double, string>(17.189877, -88.49765, "Belize"),
                new Tuple<double, double, string>(56.130366, -106.346771, "Canada"),
                new Tuple<double, double, string>(-12.164165, 96.870956, "Cocos [Keeling] Islands"),
                new Tuple<double, double, string>(-4.038333, 21.758664, "Congo [DRC]"),
                new Tuple<double, double, string>(6.611111, 20.939444, "Central African Republic"),
                new Tuple<double, double, string>(-0.228021, 15.827659, "Congo [Republic]"),
                new Tuple<double, double, string>(46.818188, 8.227512, "Switzerland"),
                new Tuple<double, double, string>(7.539989, -5.54708, "Côte d'Ivoire"),
                new Tuple<double, double, string>(-21.236736, -159.777671, "Cook Islands"),
                new Tuple<double, double, string>(-35.675147, -71.542969, "Chile"),
                new Tuple<double, double, string>(7.369722, 12.354722, "Cameroon"),
                new Tuple<double, double, string>(35.86166, 104.195397, "China"),
                new Tuple<double, double, string>(4.570868, -74.297333, "Colombia"),
                new Tuple<double, double, string>(9.748917, -83.753428, "Costa Rica"),
                new Tuple<double, double, string>(21.521757, -77.781167, "Cuba"),
                new Tuple<double, double, string>(16.002082, -24.013197, "Cape Verde"),
                new Tuple<double, double, string>(-10.447525, 105.690449, "Christmas Island"),
                new Tuple<double, double, string>(35.126413, 33.429859, "Cyprus"),
                new Tuple<double, double, string>(49.817492, 15.472962, "Czech Republic"),
                new Tuple<double, double, string>(51.165691, 10.451526, "Germany"),
                new Tuple<double, double, string>(11.825138, 42.590275, "Djibouti"),
                new Tuple<double, double, string>(56.26392, 9.501785, "Denmark"),
                new Tuple<double, double, string>(15.414999, -61.370976, "Dominica"),
                new Tuple<double, double, string>(18.735693, -70.162651, "Dominican Republic"),
                new Tuple<double, double, string>(28.033886, 1.659626, "Algeria"),
                new Tuple<double, double, string>(-1.831239, -78.183406, "Ecuador"),
                new Tuple<double, double, string>(58.595272, 25.013607, "Estonia"),
                new Tuple<double, double, string>(26.820553, 30.802498, "Egypt"),
                new Tuple<double, double, string>(24.215527, -12.885834, "Western Sahara"),
                new Tuple<double, double, string>(15.179384, 39.782334, "Eritrea"),
                new Tuple<double, double, string>(40.463667, -3.74922, "Spain"),
                new Tuple<double, double, string>(9.145, 40.489673, "Ethiopia"),
                new Tuple<double, double, string>(61.92411, 25.748151, "Finland"),
                new Tuple<double, double, string>(-16.578193, 179.414413, "Fiji"),
                new Tuple<double, double, string>(-51.796253, -59.523613, "Falkland Islands [Islas Malvinas]"),
                new Tuple<double, double, string>(7.425554, 150.550812, "Micronesia"),
                new Tuple<double, double, string>(61.892635, -6.911806, "Faroe Islands"),
                new Tuple<double, double, string>(46.227638, 2.213749, "France"),
                new Tuple<double, double, string>(-0.803689, 11.609444, "Gabon"),
                new Tuple<double, double, string>(55.378051, -3.435973, "United Kingdom"),
                new Tuple<double, double, string>(12.262776, -61.604171, "Grenada"),
                new Tuple<double, double, string>(42.315407, 43.356892, "Georgia"),
                new Tuple<double, double, string>(3.933889, -53.125782, "French Guiana"),
                new Tuple<double, double, string>(49.465691, -2.585278, "Guernsey"),
                new Tuple<double, double, string>(7.946527, -1.023194, "Ghana"),
                new Tuple<double, double, string>(36.137741, -5.345374, "Gibraltar"),
                new Tuple<double, double, string>(71.706936, -42.604303, "Greenland"),
                new Tuple<double, double, string>(13.443182, -15.310139, "Gambia"),
                new Tuple<double, double, string>(9.945587, -9.696645, "Guinea"),
                new Tuple<double, double, string>(16.995971, -62.067641, "Guadeloupe"),
                new Tuple<double, double, string>(1.650801, 10.267895, "Equatorial Guinea"),
                new Tuple<double, double, string>(39.074208, 21.824312, "Greece"),
                new Tuple<double, double, string>(-54.429579, -36.587909,
                    "South Georgia and the South Sandwich Islands"),
                new Tuple<double, double, string>(15.783471, -90.230759, "Guatemala"),
                new Tuple<double, double, string>(13.444304, 144.793731, "Guam"),
                new Tuple<double, double, string>(11.803749, -15.180413, "Guinea-Bissau"),
                new Tuple<double, double, string>(4.860416, -58.93018, "Guyana"),
                new Tuple<double, double, string>(31.354676, 34.308825, "Gaza Strip"),
                new Tuple<double, double, string>(22.396428, 114.109497, "Hong Kong"),
                new Tuple<double, double, string>(-53.08181, 73.504158, "Heard Island and McDonald Islands"),
                new Tuple<double, double, string>(15.199999, -86.241905, "Honduras"),
                new Tuple<double, double, string>(18.971187, -72.285215, "Haiti"),
                new Tuple<double, double, string>(47.162494, 19.503304, "Hungary"),
                new Tuple<double, double, string>(-0.789275, 113.921327, "Indonesia"),
                new Tuple<double, double, string>(53.41291, -8.24389, "Ireland"),
                new Tuple<double, double, string>(31.046051, 34.851612, "Israel"),
                new Tuple<double, double, string>(54.236107, -4.548056, "Isle of Man"),
                new Tuple<double, double, string>(20.593684, 78.96288, "India"),
                new Tuple<double, double, string>(-6.343194, 71.876519, "British Indian Ocean Territory"),
                new Tuple<double, double, string>(33.223191, 43.679291, "Iraq"),
                new Tuple<double, double, string>(32.427908, 53.688046, "Iran"),
                new Tuple<double, double, string>(64.963051, -19.020835, "Iceland"),
                new Tuple<double, double, string>(41.87194, 12.56738, "Italy"),
                new Tuple<double, double, string>(49.214439, -2.13125, "Jersey"),
                new Tuple<double, double, string>(18.109581, -77.297508, "Jamaica"),
                new Tuple<double, double, string>(30.585164, 36.238414, "Jordan"),
                new Tuple<double, double, string>(36.204824, 138.252924, "Japan"),
                new Tuple<double, double, string>(-0.023559, 37.906193, "Kenya"),
                new Tuple<double, double, string>(41.20438, 74.766098, "Kyrgyzstan"),
                new Tuple<double, double, string>(12.565679, 104.990963, "Cambodia"),
                new Tuple<double, double, string>(-3.370417, -168.734039, "Kiribati"),
                new Tuple<double, double, string>(-11.875001, 43.872219, "Comoros"),
                new Tuple<double, double, string>(17.357822, -62.782998, "Saint Kitts and Nevis"),
                new Tuple<double, double, string>(40.339852, 127.510093, "North Korea"),
                new Tuple<double, double, string>(35.907757, 127.766922, "South Korea"),
                new Tuple<double, double, string>(29.31166, 47.481766, "Kuwait"),
                new Tuple<double, double, string>(19.513469, -80.566956, "Cayman Islands"),
                new Tuple<double, double, string>(48.019573, 66.923684, "Kazakhstan"),
                new Tuple<double, double, string>(19.85627, 102.495496, "Laos"),
                new Tuple<double, double, string>(33.854721, 35.862285, "Lebanon"),
                new Tuple<double, double, string>(13.909444, -60.978893, "Saint Lucia"),
                new Tuple<double, double, string>(47.166, 9.555373, "Liechtenstein"),
                new Tuple<double, double, string>(7.873054, 80.771797, "Sri Lanka"),
                new Tuple<double, double, string>(6.428055, -9.429499, "Liberia"),
                new Tuple<double, double, string>(-29.609988, 28.233608, "Lesotho"),
                new Tuple<double, double, string>(55.169438, 23.881275, "Lithuania"),
                new Tuple<double, double, string>(49.815273, 6.129583, "Luxembourg"),
                new Tuple<double, double, string>(56.879635, 24.603189, "Latvia"),
                new Tuple<double, double, string>(26.3351, 17.228331, "Libya"),
                new Tuple<double, double, string>(31.791702, -7.09262, "Morocco"),
                new Tuple<double, double, string>(43.750298, 7.412841, "Monaco"),
                new Tuple<double, double, string>(47.411631, 28.369885, "Moldova"),
                new Tuple<double, double, string>(42.708678, 19.37439, "Montenegro"),
                new Tuple<double, double, string>(-18.766947, 46.869107, "Madagascar"),
                new Tuple<double, double, string>(7.131474, 171.184478, "Marshall Islands"),
                new Tuple<double, double, string>(41.608635, 21.745275, "Macedonia [FYROM]"),
                new Tuple<double, double, string>(17.570692, -3.996166, "Mali"),
                new Tuple<double, double, string>(21.913965, 95.956223, "Myanmar [Burma]"),
                new Tuple<double, double, string>(46.862496, 103.846656, "Mongolia"),
                new Tuple<double, double, string>(22.198745, 113.543873, "Macau"),
                new Tuple<double, double, string>(17.33083, 145.38469, "Northern Mariana Islands"),
                new Tuple<double, double, string>(14.641528, -61.024174, "Martinique"),
                new Tuple<double, double, string>(21.00789, -10.940835, "Mauritania"),
                new Tuple<double, double, string>(16.742498, -62.187366, "Montserrat"),
                new Tuple<double, double, string>(35.937496, 14.375416, "Malta"),
                new Tuple<double, double, string>(-20.348404, 57.552152, "Mauritius"),
                new Tuple<double, double, string>(3.202778, 73.22068, "Maldives"),
                new Tuple<double, double, string>(-13.254308, 34.301525, "Malawi"),
                new Tuple<double, double, string>(23.634501, -102.552784, "Mexico"),
                new Tuple<double, double, string>(4.210484, 101.975766, "Malaysia"),
                new Tuple<double, double, string>(-18.665695, 35.529562, "Mozambique"),
                new Tuple<double, double, string>(-22.95764, 18.49041, "Namibia"),
                new Tuple<double, double, string>(-20.904305, 165.618042, "New Caledonia"),
                new Tuple<double, double, string>(17.607789, 8.081666, "Niger"),
                new Tuple<double, double, string>(-29.040835, 167.954712, "Norfolk Island"),
                new Tuple<double, double, string>(9.081999, 8.675277, "Nigeria"),
                new Tuple<double, double, string>(12.865416, -85.207229, "Nicaragua"),
                new Tuple<double, double, string>(52.132633, 5.291266, "Netherlands"),
                new Tuple<double, double, string>(60.472024, 8.468946, "Norway"),
                new Tuple<double, double, string>(28.394857, 84.124008, "Nepal"),
                new Tuple<double, double, string>(-0.522778, 166.931503, "Nauru"),
                new Tuple<double, double, string>(-19.054445, -169.867233, "Niue"),
                new Tuple<double, double, string>(-40.900557, 174.885971, "New Zealand"),
                new Tuple<double, double, string>(21.512583, 55.923255, "Oman"),
                new Tuple<double, double, string>(8.537981, -80.782127, "Panama"),
                new Tuple<double, double, string>(-9.189967, -75.015152, "Peru"),
                new Tuple<double, double, string>(-17.679742, -149.406843, "French Polynesia"),
                new Tuple<double, double, string>(-6.314993, 143.95555, "Papua New Guinea"),
                new Tuple<double, double, string>(12.879721, 121.774017, "Philippines"),
                new Tuple<double, double, string>(30.375321, 69.345116, "Pakistan"),
                new Tuple<double, double, string>(51.919438, 19.145136, "Poland"),
                new Tuple<double, double, string>(46.941936, -56.27111, "Saint Pierre and Miquelon"),
                new Tuple<double, double, string>(-24.703615, -127.439308, "Pitcairn Islands"),
                new Tuple<double, double, string>(18.220833, -66.590149, "Puerto Rico"),
                new Tuple<double, double, string>(31.952162, 35.233154, "Palestinian Territories"),
                new Tuple<double, double, string>(39.399872, -8.224454, "Portugal"),
                new Tuple<double, double, string>(7.51498, 134.58252, "Palau"),
                new Tuple<double, double, string>(-23.442503, -58.443832, "Paraguay"),
                new Tuple<double, double, string>(25.354826, 51.183884, "Qatar"),
                new Tuple<double, double, string>(-21.115141, 55.536384, "Réunion"),
                new Tuple<double, double, string>(45.943161, 24.96676, "Romania"),
                new Tuple<double, double, string>(44.016521, 21.005859, "Serbia"),
                new Tuple<double, double, string>(61.52401, 105.318756, "Russia"),
                new Tuple<double, double, string>(-1.940278, 29.873888, "Rwanda"),
                new Tuple<double, double, string>(23.885942, 45.079162, "Saudi Arabia"),
                new Tuple<double, double, string>(-9.64571, 160.156194, "Solomon Islands"),
                new Tuple<double, double, string>(-4.679574, 55.491977, "Seychelles"),
                new Tuple<double, double, string>(12.862807, 30.217636, "Sudan"),
                new Tuple<double, double, string>(60.128161, 18.643501, "Sweden"),
                new Tuple<double, double, string>(1.352083, 103.819836, "Singapore"),
                new Tuple<double, double, string>(-24.143474, -10.030696, "Saint Helena"),
                new Tuple<double, double, string>(46.151241, 14.995463, "Slovenia"),
                new Tuple<double, double, string>(77.553604, 23.670272, "Svalbard and Jan Mayen"),
                new Tuple<double, double, string>(48.669026, 19.699024, "Slovakia"),
                new Tuple<double, double, string>(8.460555, -11.779889, "Sierra Leone"),
                new Tuple<double, double, string>(43.94236, 12.457777, "San Marino"),
                new Tuple<double, double, string>(14.497401, -14.452362, "Senegal"),
                new Tuple<double, double, string>(5.152149, 46.199616, "Somalia"),
                new Tuple<double, double, string>(3.919305, -56.027783, "Suriname"),
                new Tuple<double, double, string>(0.18636, 6.613081, "São Tomé and Príncipe"),
                new Tuple<double, double, string>(13.794185, -88.89653, "El Salvador"),
                new Tuple<double, double, string>(34.802075, 38.996815, "Syria"),
                new Tuple<double, double, string>(-26.522503, 31.465866, "Swaziland"),
                new Tuple<double, double, string>(21.694025, -71.797928, "Turks and Caicos Islands"),
                new Tuple<double, double, string>(15.454166, 18.732207, "Chad"),
                new Tuple<double, double, string>(-49.280366, 69.348557, "French Southern Territories"),
                new Tuple<double, double, string>(8.619543, 0.824782, "Togo"),
                new Tuple<double, double, string>(15.870032, 100.992541, "Thailand"),
                new Tuple<double, double, string>(38.861034, 71.276093, "Tajikistan"),
                new Tuple<double, double, string>(-8.967363, -171.855881, "Tokelau"),
                new Tuple<double, double, string>(-8.874217, 125.727539, "Timor-Leste"),
                new Tuple<double, double, string>(38.969719, 59.556278, "Turkmenistan"),
                new Tuple<double, double, string>(33.886917, 9.537499, "Tunisia"),
                new Tuple<double, double, string>(-21.178986, -175.198242, "Tonga"),
                new Tuple<double, double, string>(38.963745, 35.243322, "Turkey"),
                new Tuple<double, double, string>(10.691803, -61.222503, "Trinidad and Tobago"),
                new Tuple<double, double, string>(-7.109535, 177.64933, "Tuvalu"),
                new Tuple<double, double, string>(23.69781, 120.960515, "Taiwan"),
                new Tuple<double, double, string>(-6.369028, 34.888822, "Tanzania"),
                new Tuple<double, double, string>(48.379433, 31.16558, "Ukraine"),
                new Tuple<double, double, string>(1.373333, 32.290275, "Uganda"),
                new Tuple<double, double, string>(37.09024, -95.712891, "United States"),
                new Tuple<double, double, string>(-32.522779, -55.765835, "Uruguay"),
                new Tuple<double, double, string>(41.377491, 64.585262, "Uzbekistan"),
                new Tuple<double, double, string>(41.902916, 12.453389, "Vatican City"),
                new Tuple<double, double, string>(12.984305, -61.287228, "Saint Vincent and the Grenadines"),
                new Tuple<double, double, string>(6.42375, -66.58973, "Venezuela"),
                new Tuple<double, double, string>(18.420695, -64.639968, "British Virgin Islands"),
                new Tuple<double, double, string>(18.335765, -64.896335, "U.S. Virgin Islands"),
                new Tuple<double, double, string>(14.058324, 108.277199, "Vietnam"),
                new Tuple<double, double, string>(-15.376706, 166.959158, "Vanuatu"),
                new Tuple<double, double, string>(-13.768752, -177.156097, "Wallis and Futuna"),
                new Tuple<double, double, string>(-13.759029, -172.104629, "Samoa"),
                new Tuple<double, double, string>(42.602636, 20.902977, "Kosovo"),
                new Tuple<double, double, string>(15.552727, 48.516388, "Yemen"),
                new Tuple<double, double, string>(-12.8275, 45.166244, "Mayotte"),
                new Tuple<double, double, string>(-30.559482, 22.937506, "South Africa"),
                new Tuple<double, double, string>(-13.133897, 27.849332, "Zambia"),
                new Tuple<double, double, string>(-19.015438, 29.154857, "Zimbabwe"),
            };
        }

        public static List<Company> GetCompanies()
        {
            return new List<Company>()
            {
                new Company() {Code = 1000, Name = "Google", Logo = "https://rebootaccel.com/wp-content/uploads/2015/08/google-favicon-vector-400x400.png"},
                new Company() {Code = 1001, Name = "IBM", Logo = "http://diylogodesigns.com/blog/wp-content/uploads/2016/04/ibm-logo-png-transparent-background.png"},
                new Company() {Code = 1002, Name = "Facebook",Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cd/Facebook_logo_%28square%29.png/600px-Facebook_logo_%28square%29.png"},
                new Company() {Code = 1003, Name = "Amdocs", Logo = "https://formativecontent.com/wp-content/uploads/2017/07/amdocs.png"},
                new Company() {Code = 1004, Name = "Cloud" , Logo = "https://www.cloud3d.ltd/img/logo/cloud-logo-square-1000-blue.png"},
            };
        }

        public static List<FileType> GetFileTypes()
        {
            return new List<FileType>()
            {
                new FileType() {Language = "Python", FileExt = "py"},
                new FileType() {Language = "PowerShell", FileExt = "ps1"},
                new FileType() {Language = "Batch", FileExt = "bat"}
            };
        }

        public static List<Machine> GetMachines()
        {
            Random r = new Random();

            List<string> ips = new List<string>()
            {
                "50.116.30.23",
                "198.58.103.28",
                "198.58.103.36",
                "198.58.102.49",
                "198.58.103.91",
                "198.58.102.95",
                "198.58.103.92",
                "198.58.102.96",
                "198.58.103.114",
                "198.58.102.117",
                "198.58.103.115",
                "198.58.102.155",
                "198.58.102.156",
                "198.58.103.158",
                "198.58.102.158",
                "198.58.103.160",
                "198.58.103.102",
                "50.116.28.209",
                "198.58.96.215",
                "198.58.99.82"
            };

            var companies = GetCompanies();
            var countriesPoints = GetPoints();

            return ips.ConvertAll(ip =>
            {
                var countryPoint = countriesPoints[r.Next(1, countriesPoints.Count)];

                Machine machine = new Machine()
                {
                    IP = ip,
                    CreationDate = DateTime.Now - TimeSpan.FromHours(r.Next(5, 999)),
                    CompanyCode = companies[r.Next(1, companies.Count)].Code,
                    IsDeleted = false,
                    VLan = r.Next(1, 4000),
                    Lat = countryPoint.Item1,
                    Lon = countryPoint.Item2
                };

                return machine;
            });
        }

        public static List<Script> GetScripts(List<int> users, List<FileType> fileTypes)
        {
            Random r = new Random();

            List<string> commands = new List<string>()
            {
                "attrib",
                "comp",
                "compact",
                "copy / xcop",
                "diskcomp",
                "diskcopy",
                "erase / del",
                "expand",
                "fc",
                "mkdir",
                "move",
                "rename",
                "replace",
                "rmdir / rd",
                "tree",
                "type",
                "call",
                "cd",
                "cls",
                "cmd",
                "color",
                "date",
                "dir",
                "echo",
                "exit",
                "find",
                "hostname",
                "pause",
                "runas",
                "shutdown",
                "sort",
                "start",
                "taskkill",
                "tasklist",
                "time",
                "timeout",
                "title",
                "ver",
                "w32tm"
            };

            List<Script> scripts = commands.ConvertAll(command => new Script()
            {
                UserId = users[r.Next(1, users.Count)],
                Content = "__" + command,
                Name = "__" + command,
                CreationDate = DateTime.Now - TimeSpan.FromHours(r.Next(5, 999)),
                FileTypeId = fileTypes.First(type => type.Language == "Batch").Id,
                Cost = r.Next(1, 999),
                Description = "The description is " + command
            });

            while (scripts.Any(script => script.Version == 0 || script.Id == 0))
            {
                int id = r.Next(1, 13);

                Script exist = scripts.FirstOrDefault(script => script.Id == id);
                Script firstEmpty = scripts.First(script => script.Id == 0);

                firstEmpty.Id = id;

                firstEmpty.Version = exist == null
                    ? 1
                    : scripts.Where(script => script.Id == id).Max(script => script.Version) + 1;
            }

            return scripts;
        }

        public static List<User> GetUsers()
        {
            Random r = new Random();

            List<string> names = new List<string>()
            {
                "Andree Sassman",
                "Phung Beran",
                "Amado Noel",
                "Junie Bach",
                "Avis Yankey",
                "Lizabeth Arras",
                "Lavada Mahood",
                "Mauricio Shulman",
                "Taren Darnall",
                "Leonardo Degeorge",
                "Jen Brightman",
                "Quinn Hiner",
                "Lorilee Stickle",
                "Maisha Mansfield",
                "Shamika Pereda",
                "Phillip Machnik",
                "Leeann Stuber",
                "Rosy Heath",
                "Lucille Lundblad",
                "Dodie Gabrielson"
            };

            var companies = GetCompanies();

            List<User> users = names.ConvertAll(name => new User()
            {
                FullName = name,
                Role = Role.Viewer,
                Email = $"{name.ToLower().Replace(" ", string.Empty)}@gmail.com",
                CreationDate = DateTime.Now - TimeSpan.FromHours(r.Next(5, 9999)),
                IsDeleted = false,
                CompanyCode = companies[r.Next(1, companies.Count)].Code
            });

            users.Take(3).ToList().ForEach(user => user.Role = Role.Admin);
            users.Skip(3).Take(7).ToList().ForEach(user => user.Role = Role.Manager);

            return users;
        }

        public static List<Reason> GetReasons()
        {
            return new List<Reason>()
            {
                new Reason() {ReasonName = "Customer Asked"},
                new Reason() {ReasonName = "Maintenance"},
                new Reason() {ReasonName = "No Reason"},
                new Reason() {ReasonName = "Critical Error"},
                new Reason() {ReasonName = "Sceducale Task"},
            };
        }

        public static List<Execution> GetExecutions(int number, List<int> userIds, List<int> reasonsIds,
            List<Machine> machines)
        {
            Random r = new Random();

            var executions = new List<Execution>();

            for (int i = 0; i < number; i++)
            {
                var machine = machines[r.Next(1, machines.Count)];

                Execution execution = new Execution()
                {
                    MachineIP = machine.IP,
                    MachineVLan = machine.VLan,
                    ReasonId = reasonsIds[r.Next(1, reasonsIds.Count)],
                    UserId = userIds[r.Next(1, userIds.Count)],
                    Status = (Status)r.Next(1, 4),
                    CreationDate = DateTime.Now - TimeSpan.FromHours(r.Next(5, 999))
                };

                if (execution.Status != Status.Waiting)
                {
                    execution.SrartTime = execution.CreationDate + TimeSpan.FromMinutes(r.Next(1, 20));
                    execution.EndTime = execution.SrartTime + TimeSpan.FromMinutes(r.Next(1, 20));
                }

                executions.Add(execution);
            }

            return executions;
        }

        public static List<ExecutionsScripts> GetExecutionsScriptses(List<Execution> executions, List<Script> scripts)
        {
            Random r = new Random();

            var executionsScriptses = new List<ExecutionsScripts>();

            executions.ForEach(execution =>
            {
                int numberOfScripts = r.Next(1, 5);

                for (int i = 0; i < numberOfScripts; i++)
                {
                    Script script;
                    do
                    {
                        script = scripts[r.Next(1, scripts.Count)];
                    } while (executionsScriptses.Any(es => es.ScriptId == script.Id &&
                                                           es.ScriptVersion == script.Version &&
                                                           es.ExecutionId == execution.Id));

                    ExecutionsScripts executionsScripts = new ExecutionsScripts()
                    {
                        ExecutionId = execution.Id,
                        ScriptId = script.Id,
                        ScriptVersion = script.Version,
                        Order = i + 1,
                        Status = execution.Status
                    };

                    if (executionsScripts.Status != Status.Waiting)
                    {
                        executionsScripts.SrartTime = DateTime.Now - TimeSpan.FromHours(r.Next(5, 999));
                        executionsScripts.EndTime = executionsScripts.SrartTime + TimeSpan.FromMinutes(r.Next(1, 20));
                    }

                    executionsScriptses.Add(executionsScripts);
                }
            });

            return executionsScriptses;
        }
    }
}
