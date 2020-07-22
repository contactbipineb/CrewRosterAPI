namespace EY.CabinCrew.Core
{
    public class ExcelRow : IConvertable
    {
        public string crew_id { get; set; }
        public string crew_name { get; set; }
        public string crew_type { get; set; }
        public string rank { get; set; }
        public string block_hour_schedule { get; set; }
        public string std { get; set; }
        public string sta { get; set; }
        public string trip_rest_hours { get; set; }
        public string trip_starttime_local { get; set; }
        public string trip_starttime_local_actual { get; set; }
        public string trip_crewcount { get; set; }
        public string schd_dep_date { get; set; }
        public string flight_number { get; set; }
        public string reg { get; set; }
        public string sub_fleet { get; set; }
        public string aircraft_code { get; set; }
        public string sched_arr_iata { get; set; }
        public string sched_dep_iata { get; set; }
        public string port { get; set; }
        public string dep_country { get; set; }
        public string std_z { get; set; }
        public string std_ls { get; set; }
        public string std_z_date_time { get; set; }
        public string std_ls_date_time { get; set; }
        public string sta_z_date { get; set; }
        public string sta_z_date_time { get; set; }
        public string sta_ls_date_time { get; set; }
        public string dep_gate { get; set; }
        public string arr_gate { get; set; }

        public void Convert(string[] values)
        {
            crew_id = values[0];
            crew_name = values[1];
            crew_type = values[2];
            rank = values[3];
            block_hour_schedule = values[4];
            std = values[5];
            sta = values[6];
            trip_rest_hours = values[7];
            trip_starttime_local = values[8];
            trip_starttime_local_actual = values[9];
            trip_crewcount = values[10];
            schd_dep_date = values[11];
            flight_number = values[12];
            reg = values[13];
            sub_fleet = values[14];
            aircraft_code = values[15];
            sched_arr_iata = values[16];
            sched_dep_iata = values[17];
            port = values[18];
            dep_country = values[19];
            std_z = values[20];
            std_ls = values[21];
            std_z_date_time = values[22];
            std_ls_date_time = values[23];
            sta_z_date = values[24];
            sta_z_date_time = values[25];
            sta_ls_date_time = values[26];
            dep_gate = values[27];
            arr_gate = values[28];

        }
    }
}
