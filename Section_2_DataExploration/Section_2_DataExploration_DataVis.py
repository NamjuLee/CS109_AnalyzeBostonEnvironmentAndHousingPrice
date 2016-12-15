

######################################################################## Housing Price 
import json
import Rhino as r
def OpenJson(path):
    json_file = open(path , 'r')
    json_str = json_file.read()
    json_data = json.loads(json_str)
    return json_data
d = OpenJson(x)
pts = []
ptsZ = []
scale = sc * 0.0000001
radi = []
for i in d:
    if(i['lat'] != -1 ): 
        try:
            y = i['lat']
            x = i["long"]
            z = i['prices']
            zz = z.split(",")
            z1 = zz[0] 
            z2 = zz[1]
            z = float( z1+z2) 
            pts.append(r.Geometry.Point3d(x,y,0))
            ptsZ.append(r.Geometry.Point3d(x,y, z * scale ))
            radi.append(z*scale)
        except:
            pass
######################################################################## Rent Price 
import json
import Rhino as r
def OpenJson(path): 
    json_file = open(path , 'r')
    json_str = json_file.read()
    json_data = json.loads(json_str)
    return json_data
d = OpenJson(x)
pts = []
ptsZ = []
scale = sc * 0.0000001
radi = []
for i in d:
    y = i['Latitude']
    x = i['Longitude']
    z = i['Price']
    pts.append(r.Geometry.Point3d(x,y,0))
######################################################################## crime Price  
import json
import Rhino as r
def OpenJson(path): 
    json_file = open(path , 'r')
    json_str = json_file.read()
    json_data = json.loads(json_str)
    return json_data
d = OpenJson(x)
pts = []
for i in d:
    y = i['coordinates'][0]
    x = i["coordinates"][1]
    pts.append(r.Geometry.Point3d(x,y,0))
jsonString = []
for i in d:
    theString = "pos:" + str(i['coordinates'][0]) +","+ str(i['coordinates'][1])
    theString += "_type:" + i['type']
    jsonString.append(theString)
######################################################################## google street view
import json
import Rhino as r
def OpenJson(path): 
    json_file = open(path , 'r')
    json_str = json_file.read()
    json_data = json.loads(json_str)
    return json_data
d = OpenJson(x)
pts = []
for i in d['data']:
    y = i['coordinates'][1]
    x = i["coordinates"][0]
    pts.append(r.Geometry.Point3d(x,y,0))
totalPixel = 384 * 384 * 5
jsonString = []
for i in d['data']:
    theString = "pos:" + str(i['coordinates'][1]) +","+ str(i['coordinates'][0])
    try:    theString += "_" + str(i['3'][0]) + ":" + str(i['3'][1]/totalPixel * 100)[0:5]
    except: theString += "_sky:0"
    try:    theString += "_" + str(i['5'][0]) + ":" + str(i['5'][1]/totalPixel * 100)[0:5]
    except: theString += "_tree:0"
    try:    theString += "_" + str(i['10'][0]) + ":" + str(i['10'][1]/totalPixel * 100)[0:5]
    except: theString += "_grass:0"
    try:    theString += "_" + str(i['129'][0]) + ":" + str(i['129'][1]/totalPixel * 100)[0:5]
    except: theString += "_lake:0"
    try:    theString += "_building:" + str(i['2'][1]/totalPixel * 100)[0:5]
    except: theString += "_building:0"
    try:    theString += "_house:" + str(i['26'][1]/totalPixel * 100)[0:5]
    except: theString += "_house:0"
    try:    theString += "_sidewalk:" + str(i['12'][1]/totalPixel * 100)[0:5]
    except: theString += "_sidewalk:0"
    try:    theString += "_car:" + str(i['21'][1]/totalPixel * 100)[0:5]
    except: theString += "_car:0"
    try:    theString += "_person:" + str(i['18'][1]/totalPixel * 100)[0:5]
    except: theString += "_person:0"
    try:    theString += "_road:" + str(i['7'][1]/totalPixel * 100)[0:5]
    except: theString += "_road:0"
    try:    theString += "_plant:" + str(i['19'][1]/totalPixel * 100)[0:5]
    except: theString += "_plant:0"
    try:    theString += "_wall:" + str(i['1'][1]/totalPixel * 100)[0:5]
    except: theString += "_wall:0"
    try:    theString += "_ground:" + str(i['95'][1]/totalPixel * 100)[0:5]
    except: theString += "_ground:0"
    try:    theString += "_ceiling:" + str(i['6'][1]/totalPixel * 100)[0:5]
    except: theString += "_ceiling:0"
    try:    theString += "_river:" + str(i['61'][1]/totalPixel * 100)[0:5]
    except: theString += "_river:0"
    try:    theString += "_sign:" + str(i['44'][1]/totalPixel * 100)[0:5]
    except: theString += "_sign:0"
    try:    theString += "_bridge:" + str(i['62'][1]/totalPixel * 100)[0:5]
    except: theString += "_bridge:0"
    try:    theString += "_palmTree:" + str(i['73'][1]/totalPixel * 100)[0:5]
    except: theString += "_palmTree:0"
    try:    theString += "_path:" + str(i['53'][1]/totalPixel * 100)[0:5]
    except: theString += "_path:0"
    try:    theString += "_pole:" + str(i['94'][1]/totalPixel * 100)[0:5]
    except: theString += "_pole:0"
    try:    theString += "_sea:" + str(i['27'][1]/totalPixel * 100)[0:5]
    except: theString += "_sea:0"
    try:    theString += "_railing:" + str(i['39'][1]/totalPixel * 100)[0:5]
    except: theString += "_railing:0"
    try:    theString += "_field:" + str(i['30'][1]/totalPixel * 100)[0:5]
    except: theString += "_field:0"
    try:    theString += "_mountain:" + str(i['17'][1]/totalPixel * 100)[0:5]
    except: theString += "_mountain:0"
    try:    theString += "_grandstand:" + str(i['52'][1]/totalPixel * 100)[0:5]
    except: theString += "_grandstand:0"
    try:    theString += "_van:" + str(i['103'][1]/totalPixel * 100)[0:5]
    except: theString += "_van:0"
    try:    theString += "_window:" + str(i['9'][1]/totalPixel * 100)[0:5]
    except: theString += "_window:0"
    try:    theString += "_bus:" + str(i['81'][1]/totalPixel * 100)[0:5]
    except: theString += "_bus:0"
    jsonString.append(theString)
######################################################################## Craigslist
import json
import Rhino as r
def OpenJson(path): 
    json_file = open(path , 'r')
    json_str = json_file.read()
    json_data = json.loads(json_str)
    return json_data
house = OpenJson(fn1)
room = OpenJson(fn2)
titleHouse = []
posHouse = []
for i in house:
    if(type(i['pos']) != type([])):
        try:
            x = i['pos']['long']
            y = i['pos']['lat']
            posHouse.append(r.Geometry.Point3d(x,y,0))
            titleHouse.append(i['title'])
        except:
            pass
titleRoom = []
posRoom = []
for i in room:
    if(type(i['pos']) != type([])):
        try:
            x = i['pos']['long']
            y = i['pos']['lat']
            posRoom.append(r.Geometry.Point3d(x,y,0))
            titleRoom.append(i['title'])
        except:
            pass
######################################################################## google place
import json
import Rhino as r
def OpenJson(path): 
    json_file = open(path , 'r')
    json_str = json_file.read()
    json_data = json.loads(json_str)
    return json_data
d = OpenJson(x)
print [i for i in d]
school = []
for i in d['school']:
    school.append(r.Geometry.Point3d(i['long'],i['lat'],0)) 
university = []
for i in d['university']:
    university.append(r.Geometry.Point3d(i['long'],i['lat'],0)) 
mbta = []
for i in d['bus_station']:
    mbta.append(r.Geometry.Point3d(i['long'],i['lat'],0)) 
for i in d['subway_station']:
    mbta.append(r.Geometry.Point3d(i['long'],i['lat'],0)) 
park = []
for i in d['park']:
    park.append(r.Geometry.Point3d(i['long'],i['lat'],0)) 
######################################################################## Property_Assessment_2016
import json
import Rhino as r
def OpenJson(path):
    json_file = open(path , 'r')
    json_str = json_file.read()
    json_data = json.loads(json_str)
    return json_data
d = OpenJson(x)
val = []
pts = []
ptsZ = []
for i in d:
    x = i["LONGITUDE"]
    y = i["LATITUDE"]
    z = i["AV_LAND"]
    val.append(z)
    pts.append(r.Geometry.Point3d(x,y,0))
    ptsZ.append(r.Geometry.Point3d(x,y,(z*sc) / 1000000))
######################################################################## energy in boston
import json
import Rhino as r
def OpenJson(path): 
    json_file = open(path , 'r')
    json_str = json_file.read()
    json_data = json.loads(json_str)
    return json_data
d = OpenJson(x)
val = []
pts = []
ptsZ = []
for i in d:
    va = i["Site_EUI"]
    if va < max:
        val.append(va)
        pos = i["pos"].split(",")
        print pos
        x = float(pos[0])
        y = float(pos[1])
        pts.append(r.Geometry.Point3d(x,y,0))