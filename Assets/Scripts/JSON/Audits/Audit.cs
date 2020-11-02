[System.Serializable]
public class Audit
{
	public string auditID;
	public string auditType;
	public string latlng;
	public string date;
	public string score;
	public Location location;
	public Suggestion[] summaryReport;
	public Category[] detailedReport;
}