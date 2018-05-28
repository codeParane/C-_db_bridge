using System;
using System.Collections.Generic;
using System.Data;
using EFCoreDemo;
using System.Timers;
using System.Threading.Tasks;


namespace tttt
{
    class Program
    {
       static String frmTbl_last_record ="", toTbl_last_record="";
       static int frmTbl_last_rows=0;
        static void Main(string[] args)
        {
            //timer to run method for every 1 minutes
            int prevMin = 0;
            while(true){    
                int curMin = DateTime.Now.Second;
                if(prevMin != curMin){
                    ex();
                    prevMin = curMin  + 5;
                }

            }

        }

        public static void ex(){
                //gether data from tbl_from
                DataTable ds = new DataTable();
                using (var context = new From_Context())
                {
                   
                    ds.Columns.Add("Books");
                    ds.Columns.Add("Authors");

                    foreach(var au in context.tb_data){
                       // ds.Rows.Add
                        ds.Rows.Add(au.Books, au.Authors);
                    }
                    frmTbl_last_record = ds.Rows[(ds.Rows.Count-1)][0].ToString();
                }
                //gather data from tbl_to
                DataTable ds2 = new DataTable();
                using (var context = new To_Context())
                {
                   
                    ds2.Columns.Add("Books");
                    ds2.Columns.Add("Authors");

                    foreach(var au in context.tb_data){
                       // ds.Rows.Add
                        ds2.Rows.Add(au.Books, au.Authors);
                    }
                      frmTbl_last_rows = ds.Rows.Count-1;
                    if(ds2.Rows.Count !=0){
                        toTbl_last_record = ds2.Rows[(ds2.Rows.Count-1)][0].ToString();
                      
                    }           
                }

                

                if(frmTbl_last_record != toTbl_last_record){
                    using (var context = new To_Context())
                    { 
                        var book = new Book{};
                        int i;
                        for(i=frmTbl_last_rows; i<= ds.Rows.Count-1;i++){
                            
                                book = new Book {                 
                                    Books = ds.Rows[i][0].ToString(), Authors=ds.Rows[i][1].ToString()
                                };
                            
                            context.Add(book);
                            context.SaveChanges();
                            toTbl_last_record = ds.Rows[i][0].ToString();
                        }
                       
                       
                        Console.WriteLine("Data Changes Made New Record added Succesfully");
                    }
                }
        }
    }
}
