
  public class PixelData{
    List<Pixel> pixels = new List<Pixel>();
    public double theToleranceDis = 0.0015;
    public double walkerableDis = -1;
    public PixelData(){

    }
    public void Init(List<Point3d> pts){
      foreach(Point3d p in pts){
        Pixel pix = new Pixel(p);
        pixels.Add(pix);
      }
    }
    public void SetWalkableDis(double dis){
      walkerableDis = dis / 47.0;
    }
    public List<string> DebegString = new List<string>();
    public void PushGoogleStreet(List<string> theString){
      DebegString = new List<string>();
      foreach(string s in theString){
        string[] str = s.Split('_');
        string[] pos = str[0].Split(':');
        pos = pos[1].Split(',');
        double y = double.Parse(pos[0]);
        double x = double.Parse(pos[1]);
        Point3d thePt = new Point3d(x, y, 0);
        DebegString.Add(s);
        foreach(Pixel px in pixels){
          if(px.pos.DistanceTo(thePt) < 0.001){
            px.numberSky = double.Parse(str[2].Split(':')[1]);
            px.numberTree = double.Parse(str[3].Split(':')[1]);
            px.numberGrass = double.Parse(str[4].Split(':')[1]);
            px.numberLake = double.Parse(str[5].Split(':')[1]);
            px.numberBuilding = double.Parse(str[6].Split(':')[1]);
            px.numberHouse = double.Parse(str[7].Split(':')[1]);
            px.numberSidewalk = double.Parse(str[8].Split(':')[1]);
            px.numberCar = double.Parse(str[9].Split(':')[1]);
            px.numberPerson = double.Parse(str[9].Split(':')[1]);
            px.numberRoad = double.Parse(str[10].Split(':')[1]);
            px.numberPlant = double.Parse(str[11].Split(':')[1]);
            px.numberWall = double.Parse(str[12].Split(':')[1]);
            px.numberGround = double.Parse(str[13].Split(':')[1]);
            px.numberCeiling = double.Parse(str[14].Split(':')[1]);
            px.numberRiver = double.Parse(str[15].Split(':')[1]);
            px.numberSign = double.Parse(str[16].Split(':')[1]);
            px.numberBridge = double.Parse(str[17].Split(':')[1]);
            px.numberPalmTree = double.Parse(str[18].Split(':')[1]);
            px.numberPath = double.Parse(str[19].Split(':')[1]);
            px.numberPole = double.Parse(str[20].Split(':')[1]);
            px.numberSea = double.Parse(str[21].Split(':')[1]);
            px.numberRailing = double.Parse(str[22].Split(':')[1]);
            px.numberField = double.Parse(str[23].Split(':')[1]);
            px.numberMountain = double.Parse(str[24].Split(':')[1]);
            px.numberGrandstand = double.Parse(str[25].Split(':')[1]);
            px.numberVan = double.Parse(str[26].Split(':')[1]);
            px.numberWindow = double.Parse(str[27].Split(':')[1]);
            px.numberBus = double.Parse(str[28].Split(':')[1]);
          }
        }
      }
    }
    public void PushCrime(List<string> theString){
      foreach(string s in theString){
        string[] str = s.Split('_');
        string[] pos = str[0].Split(':');
        pos = pos[1].Split(',');
        double y = double.Parse(pos[0]);
        double x = double.Parse(pos[1]);
        Point3d thePt = new Point3d(x, y, 0);
        foreach(Pixel px in pixels){
          if(px.pos.DistanceTo(thePt) < 0.0015){
            px.numberCrime++;
          }
        }
      }
    }
    public void CraigslistHouse(List<Point3d> pts){
      foreach(Point3d p in pts){
        foreach(Pixel px in pixels){
          if(px.pos.DistanceTo(p) < 0.0015){
            px.numCraigslistHouse++;
          }
        }
      }
    }
    public void CraigslistRoom(List<Point3d> pts){
      foreach(Point3d p in pts){
        foreach(Pixel px in pixels){
          if(px.pos.DistanceTo(p) < 0.0015){
            px.numCraigslistRoom++;
          }
        }
      }
    }
    public void PushGooglePlaceUniversity(List<Point3d> pts){
      foreach(Point3d p in pts){
        foreach(Pixel px in pixels){
          if(px.pos.DistanceTo(p) < this.walkerableDis){
            px.numUni++;
          }
        }
      }
    }
    public void PushGooglePlaceSchool(List<Point3d> pts){
      foreach(Point3d p in pts){
        foreach(Pixel px in pixels){
          if(px.pos.DistanceTo(p) < this.walkerableDis){
            px.numSchool++;
          }
        }
      }
    }
    public void PushGooglePlaceMbta(List<Point3d> pts){
      foreach(Point3d p in pts){
        foreach(Pixel px in pixels){
          if(px.pos.DistanceTo(p) < this.walkerableDis){
            px.numMbta++;
          }
        }
      }
    }
    public void PushGooglePlacePark(List<Point3d> pts){
      foreach(Point3d p in pts){
        foreach(Pixel px in pixels){
          if(px.pos.DistanceTo(p) < this.walkerableDis){
            px.numPark++;
          }
        }
      }
    }
    public void PushPropertyVal(List<Point3d> pts, List<double> val){
      for(int i = 0; i < pts.Count; ++i){
        foreach(Pixel px in pixels){
          if(px.pos.DistanceTo(pts[i]) < 0.0015){
            px.totalSumofProperties += val[i];
          }
        }
      }
    }
    public void PushEnergy(List<Point3d> pts, List<double> val){
      for(int i = 0; i < pts.Count; ++i){
        foreach(Pixel px in pixels){
          if(px.pos.DistanceTo(pts[i]) < 0.0015){
            px.energySiteEUI += val[i];
          }
        }
      }
    }
    public Pixel GetPixelFromPt(Point3d p){
      double dis = 1000.0;
      Pixel ppx = null;
      foreach(Pixel px in this.pixels){
        double newDis = px.pos.DistanceTo(p);
        if(newDis < dis) {
          dis = newDis;
          ppx = px;
        }
      }
      return ppx;
    }
    public List<string> GetLocation(List<Point3d> pts){
      List<string> outString = new List<string>();
      foreach(Point3d pt in pts){
        outString.Add(GetLocation(pt));
      }
      return outString;
    }
    public string GetLocation(Point3d p){
      Pixel px = GetPixelFromPt(p);
      return px.GetData();
    }
  }


  public class Pixel{
    public Point3d pos;
    public int numberCrime = 0;
    public double numberSky = 0;
    public double numberTree = 0;
    public double numberGrass = 0;
    public double numberLake = 0;
    public double numberBuilding = 0;
    public double numberHouse = 0;
    public double numberSidewalk = 0;
    public double numberCar = 0;
    public double numberPerson = 0;
    public double numberRoad = 0;
    public double numberPlant = 0;
    public double numberWall = 0;
    public double numberFence = 0;
    public double numberGround = 0;
    public double numberCeiling = 0;
    public double numberRiver = 0;
    public double numberSign = 0;
    public double numberBridge = 0;
    public double numberPalmTree = 0;
    public double numberPath = 0;
    public double numberPole = 0;
    public double numberSea = 0;
    public double numberRailing = 0;
    public double numberField = 0;
    public double numberMountain = 0;
    public double numberGrandstand = 0;
    public double numberVan = 0;
    public double numberWindow = 0;
    public double numberBus = 0;
    public double energySiteEUI = 0;
    public double totalSumofProperties = 0;
    public int numCraigslistHouse = 0;
    public int numCraigslistRoom = 0;
    public int numUni = 0;
    public int numSchool = 0;
    public int numMbta = 0;
    public int numPark = 0;
    public Pixel(Point3d p){
      pos = new Point3d(p.X, p.Y, p.Z);
    }
    public void UpdateCrime(Point3d p){

    }
    public string GetData(){
      string data = "";
      data += "pixelSky:" + numberSky.ToString();
      data += ",pixelBuilding:" + numberBuilding.ToString();
      data += ",pixelTree:" + numberTree.ToString();
      data += ",pixelRoad:" + numberRoad.ToString();
      data += ",pixelPlant:" + numberPlant.ToString();
      data += ",pixelGrass:" + numberGrass.ToString();
      data += ",pixelWall:" + numberWall.ToString();
      data += ",pixelCar:" + numberCar.ToString();
      data += ",pixelHouse:" + numberHouse.ToString();
      data += ",pixelFence:" + numberFence.ToString();
      data += ",pixelGround:" + numberGround.ToString();
      data += ",pixelCeiling:" + numberCeiling.ToString();
      data += ",pixelRiver:" + numberRiver.ToString();
      data += ",pixelSign:" + numberSign.ToString();
      data += ",pixelBridge:" + numberBridge.ToString();
      data += ",pixelPalmTree:" + numberPalmTree.ToString();
      data += ",pixelPath:" + numberPath.ToString();
      data += ",pixelPole:" + numberPole.ToString();
      data += ",pixelSea:" + numberSea.ToString();
      data += ",pixelRailing:" + numberRailing.ToString();
      data += ",pixelField:" + numberField.ToString();
      data += ",pixelMountain:" + numberMountain.ToString();
      data += ",pixelGrandstand:" + numberGrandstand.ToString();
      data += ",pixelVan:" + numberVan.ToString();
      data += ",pixelWindow:" + numberWindow.ToString();
      data += ",pixelBus:" + numberBus.ToString();
      data += ",pixelLake:" + numberLake.ToString();
      data += ",pixelSidewalk:" + numberSidewalk.ToString();
      data += ",pixelPerson:" + numberPerson.ToString();
      data += ",crime:" + numberCrime.ToString();
      data += ",numCraigslistHouse:" + numCraigslistHouse.ToString();
      data += ",numCraigslistRoom:" + numCraigslistRoom.ToString();
      data += ",walkMbta:" + numMbta.ToString();
      data += ",walkSchool:" + numSchool.ToString();
      data += ",walkUniversity:" + numUni.ToString();
      data += ",walkPark:" + numPark.ToString();
      data += ",propertiesAsses:" + totalSumofProperties.ToString();
      data += ",energySiteEUI:" + energySiteEUI.ToString();
      return data;
    }
  }


