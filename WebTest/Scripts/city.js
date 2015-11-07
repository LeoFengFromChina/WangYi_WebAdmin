getcity = function () {
    var province = ["北京", "上海", "天津", "重庆", "浙江", "江苏", "广东", "福建", "湖南", "湖北", "辽宁",
                    "吉林", "黑龙江", "河北", "河南", "山东", "陕西", "甘肃", "新疆", "青海", "山西", "四川",
                    "贵州", "安徽", "江西", "云南", "内蒙古", "西藏", "广西", "宁夏", "海南", "香港", "澳门", "台湾"
    ];
    //定义数组,存储城市信息
    var beijing = ["东城区", "西城区", "海淀区", "朝阳区", "丰台区", "石景山区", "通州区", "顺义区", "房山区", "大兴区", "昌平区", "怀柔区", "平谷区", "门头沟区", "延庆县", "密云县"];
    var shanghai = ["浦东新区", "徐汇区", "长宁区", "普陀区", "闸北区", "虹口区", "杨浦区", "黄浦区", "卢湾区", "静安区", "宝山区", "闵行区", "嘉定区", "金山区", "松江区", "青浦区", "南汇区", "奉贤区", "崇明县"];
    var tianjing = ["东丽", "北辰", "北辰", "南开", "和平", "和平", "塘沽", "大港", "宁河", "宁河", "宝坻", "武清", "武清", "汉沽", "河东", "河东", "河北", "河北", "河西", "津南", "津南", "滨海新区", "红桥", "蓟县", "西青", "西青", "静海"];
    var chongqing = ["渝中区", "大渡口区", "江北区", "沙坪坝区", "九龙坡区", "南岸区", "北碚区", "渝北区", "巴南区", "涪陵区", "綦江区", "大足区", "长寿区", "江津区", "合川区", "永川区", "南川区", "铜梁区", "璧山区", "潼南区", "荣昌区", "万州区", "梁平县", "城口县", "丰都县", "垫江县", "忠县", "开县", "云阳县", "奉节县", "巫山县", "黔江区", "武隆县", "石柱土家族自治县", "秀山土家族苗族自治县", "酉阳土家族苗族自治县", "彭水苗族土家族自治县", "巫溪县", "万盛区", "双桥区"];
    var jiangsu = ["南京", "南通", "宿迁", "常州", "徐州", "扬州", "无锡", "泰州", "淮安", "盐城", "胥浦", "苏州", "连云港", "镇江"];
    var zhejiang = ["杭州", "宁波", "温州", "嘉兴", "湖州", "绍兴", "金华", "衢州", "舟山", "台州", "丽水", "宁波"];
    var guangdong = ["广州", "韶关", "深圳", "珠海", "汕头", "佛山", "江门", "湛江", "茂名", "肇庆", "惠州", "梅州", "汕尾", "河源", "阳江", "清远", "东莞", "中山", "潮州", "揭阳", "云浮"];
    var fujiang = ["福州", "厦门", "莆田", "三明", "泉州", "漳州", "南平", "龙岩", "宁德", "平潭"];
    var hunan = ["长沙", "株洲", "湘潭", "衡阳", "邵阳", "岳阳", "常德", "张家界", "益阳", "郴州", "永州", "怀化", "娄底", "湘西土家苗族自治区"];
    var hubei = ["仙桃市", "十堰市", "咸宁市", "天门市", "孝感市", "宜昌市", "恩施土家族苗族自治州", "武汉市", "潜江市", "神农架林区", "荆州", "荆门市", "襄阳市", "鄂州市", "随州市", "黄冈", "黄石市"];
    var liaoning = ["沈阳", "大连", "鞍山", "抚顺", "本溪", "丹东", "锦州", "营口", "阜新", "辽阳", "盘锦", "铁岭", "朝阳", "葫芦岛"];
    var jilin = ["长春", "吉林", "四平", "辽源", "通化", "白山", "松原", "白城", "延边朝鲜族自治区", "长白山管委会", "梅河口", "公主岭"];
    var heilongjiang = ["哈尔滨", "齐齐哈尔", "鸡西", "牡丹江", "佳木斯", "大庆", "伊春", "黑河", "大兴安岭", "鹤岗", "双鸭山", "七台河", "绥化", "大兴安岭地区", "绥芬河", "抚远县"];
    var hebei = ["石家庄", "保定", "唐山", "邯郸", "承德", "廊坊", "衡水", "秦皇岛", "张家口", "邢台", "沧州"];
    var henan = ["郑州", "洛阳", "商丘", "安阳", "南阳", "开封", "平顶山", "焦作", "新乡", "鹤壁", "许昌", "漯河", "三门峡", "信阳", "周口", "驻马店", "济源"];
    var shandong = ["济南", "青岛", "菏泽", "淄博", "枣庄", "东营", "烟台", "潍坊", "济宁", "泰安", "威海", "日照", "滨州", "德州", "聊城", "临沂", "莱芜"];
    var shangxi = ["西安", "宝鸡", "咸阳", "渭南", "铜川", "延安", "榆林", "汉中", "安康", "商洛", "杨凌示范区"];
    var gansu = ["兰州", "嘉峪关", "金昌", "金川", "白银", "天水", "武威", "张掖", "酒泉", "平凉", "庆阳", "定西", "陇南", "临夏", "合作", "甘南"];
    var qinghai = ["西宁", "海东地区", "海北藏族自治州", "黄南藏族自治州", "海南藏族自治州", "果洛藏族自治州", "玉树藏族自治州", "海西蒙古族藏族自治州"];
    var xinjiang = ["乌鲁木齐", "奎屯", "石河子", "昌吉", "吐鲁番", "库尔勒", "阿克苏", "喀什", "伊宁", "克拉玛依", "塔城", "哈密", "和田", "阿勒泰", "阿图什", "博乐", "博尔塔拉", "巴音郭楞", "克孜勒苏柯尔克孜自治州", "伊犁哈萨克", "阿拉尔", "图木舒克", "五家渠", "北屯", "铁门关", "双河", "可克达拉"];
    var shanxi = ["太原", "大同", "阳泉", "长治", "晋城", "朔州", "晋中", "运城", "忻州", "临汾", "吕梁"];
    var sichuan = ["成都", "自贡", "攀枝花", "泸州", "德阳", "绵阳", "广元", "遂宁", "内江", "乐山", "南充", "眉山", "宜宾", "广安", "达州", "雅安", "巴中", "资阳", "阿坝藏族羌族自治州", "甘孜藏族自治州", "凉山彝族自治州"];
    var guizhou = ["贵阳", "六盘水", "遵义", "安顺", "黔南布依族苗族自治州", "黔西南布依族苗族自治州", "黔东南苗族侗族自治州", "铜仁", "毕节", "兴义市"];
    var anhui = ["亳州", "六安", "合肥", "安庆", "亳州市", "宣城", "宿州", "巢湖", "池州", "淮北", "淮南", "滁州", "芜湖", "蚌埠", "铜陵", "阜阳", "马鞍山", "黄山"];
    var jiangxi = ["南昌", "九江", "景德镇", "萍乡", "新余", "鹰潭", "赣州", "宜春", "上饶", "吉安", "抚州"];
    var yunnan = ["昆明", "曲靖", "玉溪", "保山", "昭通", "丽江", "普洱", "临沧", "楚雄彝族自治州", "大理白族自治州", "红河哈尼族彝族自治州", "文山壮族苗族自治州", "西双版纳傣族自治州", "德宏傣族景颇族自治州", "怒江傈僳族自治州", "迪庆藏族自治州"];
    var neimenggu = ["呼和浩特", "包头", "乌海", "赤峰", "通辽", "鄂尔多斯", "呼伦贝尔", "巴彦淖尔", "乌兰察布", "兴安盟", "锡林郭勒盟", "阿拉善盟"];
    var guangxi = ["南宁", "柳州", "桂林", "梧州", "北海", "防城港", "钦州", "贵港", "玉林", "百色", "贺州", "河池", "崇左", "来宾"];
    var xizang = ["拉萨", "昌都地区", "林芝地区", "山南地区", "日喀则地区", "那曲地区", "阿里地区"];
    var ningxia = ["银川", "石嘴山", "吴忠", "固原", "中卫"];
    var hainan = ["海口", "三亚"];
    var xianggang = ["中西区", "湾仔区", "东区", "南区", "九龙城区", "油尖旺区", "观塘区", "黄大仙区", "深水埗区", "北区", "大埔区", "沙田区", "西贡区", "元朗区", "屯门区", "荃湾区", "葵青区", "离岛区"];
    var taiwan = ["台北", "高雄", "基隆", "台中", "台南", "新竹", "嘉义"];
    var aomeng = ["澳门半岛", "氹仔岛", "路环岛"];

    var _CityData = {
        label: '中国',
        provinces: []
    };
    for (var i = 0; i < province.length; i++) {
        var _obj_city = {}
        _obj_city.label = province[i];
        _obj_city.cities = [];

        var proCity = [];
        switch (_obj_city.label) {
            case "北京":
                proCity = beijing;
                break;
            case "上海":
                proCity = shanghai;
                break;
            case "天津":
                proCity = tianjing;
                break;
            case "重庆":
                proCity = chongqing;
                break;
            case "浙江":
                proCity = zhejiang;
                break;
            case "江苏":
                proCity = jiangsu;
                break;
            case "广东":
                proCity = guangdong;
                break;
            case "福建":
                proCity = fujiang;
                break;
            case "湖南":
                proCity = hunan;
                break;
            case "湖北":
                proCity = hubei;
                break;
            case "辽宁":
                proCity = liaoning;
                break;
            case "吉林":
                proCity = jilin;
                break;
            case "黑龙江":
                proCity = heilongjiang;
                break;
            case "河北":
                proCity = hebei;
                break;
            case "河南":
                proCity = henan;
                break;
            case "山东":
                proCity = shandong;
                break;
            case "陕西":
                proCity = shangxi;
                break;
            case "甘肃":
                proCity = gansu;
                break;
            case "新疆":
                proCity = xinjiang;
                break;
            case "青海":
                proCity = qinghai;
                break;
            case "山西":
                proCity = shanxi;
                break;
            case "四川":
                proCity = sichuan;
                break;
            case "贵州":
                proCity = guizhou;
                break;
            case "安徽":
                proCity = anhui;
                break;
            case "江西":
                proCity = jiangxi;
                break;
            case "云南":
                proCity = yunnan;
                break;
            case "内蒙古":
                proCity = neimenggu;
                break;
            case "西藏":
                proCity = xizang;
                break;
            case "广西":
                proCity = guangxi;
                break;
            case "":
                proCity = xizang;
                break;
            case "宁夏":
                proCity = ningxia;
                break;
            case "海南":
                proCity = hainan;
                break;
            case "香港":
                proCity = xianggang;
                break;
            case "澳门":
                proCity = aomeng;
                break;
            case "台湾":
                proCity = taiwan;
                break;
        }
        for (var j = 0; j < proCity.length; j++) {
            var _city = {};
            _city.label = proCity[j];
            _obj_city.cities.push(_city);

        }
        _CityData.provinces.push(_obj_city);
    }


    var r = [];
    r.push(_CityData);
    console.log(window.JSON.stringify(r));

    return r;
}