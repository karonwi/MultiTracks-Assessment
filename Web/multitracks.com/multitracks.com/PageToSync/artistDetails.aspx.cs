using DataAccess;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class ArtistDetails : MultitracksPage
{
    public ArtistDetails()
    {
        Load += Page_Load;
    }
    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {
            var artistID = Request.QueryString["ID"]?? "31";
            if (string.IsNullOrEmpty(artistID))
            {
                ErrorLabel.Text = "Invalid artist ID.";
                ErrorLabel.Visible = true;
                return;
            }


            var sql = new SQL();
            sql.Parameters.Add("artistID", artistID);
            var dataResult = sql.ExecuteStoredProcedureDS("GetArtistDetails");

            DataTable table = dataResult.Tables[0];

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];

                Biography.Text = row["biography"].ToString();
                heroImage.ImageUrl = row["heroURL"].ToString();
                heroImage.Attributes["srcset"] = row["heroURL"] + ", " + row["heroURL"] + " 2x";
                bannerImage.ImageUrl = row["AlbumImageURL"].ToString();
                bannerImage.Attributes["srcset"] = row["artistImageUrl"] + ", " + row["artistImageUrl"] + " 2x";
                BannerName.Text = row["albumTitle"].ToString();

            }



            
        }
        catch (Exception exception)
        {
            ErrorLabel.Text = "Sorry, an error occurred while loading artist details. Please try again later.";
            ErrorLabel.Visible = true;
        }
    }

}
