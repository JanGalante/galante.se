/*
Copyright (c) 2009, comScore Inc. All rights reserved.
version: 4.5.3
*/

COMSCORE.SiteRecruit.Broker.config = {
	version: "4.5.3",
		testMode: false,
	// cookie settings
	cookie:{
		name: 'msresearch',
		path: '/',
		domain:  '.microsoft.com' ,
		duration: 90,
		rapidDuration: 0,
		expireDate: ''
	},

	eddListenerUrl: '',
	
	// optional prefix for pagemapping's pageconfig file
	prefixUrl: "",

		mapping:[
	// m=regex match, c=page config file (prefixed with configUrl), f=frequency
	{m: '//[\\w\\.-]+/athome/', c: 'inv_c_3331mt3.js', f: 0.0126, p: 0 	}
	,{m: '//[\\w\\.-]+/atwork', c: 'inv_c_3331mt5.js', f: 0.059, p: 0 	}
	,{m: '//[\\w\\.-]+/australia/athome/', c: 'inv_c_p15466742-au-372.js', f: 0.25, p: 0 	}
	,{m: '//[\\w\\.-]+/australia/athome/default\\.mspx$', c: 'inv_c_p15466742-au-372-flashfix.js', f: 0.25, p: 1 	}
	,{m: '//[\\w\\.-]+/australia/business/', c: 'inv_c_p15466742-au-373.js', f: 0.3, p: 0 	}
	,{m: '//[\\w\\.-]+/australia/business/(default\\.aspx)?$', c: 'inv_c_p15466742-au-373-SB-FIXED.js', f: 0.3, p: 1 	}
	,{m: '//[\\w\\.-]+/australia/windows/', c: 'inv_c_p15466742-au-826.js', f: 0.014, p: 0 	}
	,{m: '//[\\w\\.-]+/de/de/(default\\.aspx)?$', c: 'inv_c_p15466742-p17637473-Germany-HP.js', f: 0.005, p: 0 	}
	,{m: '//[\\w\\.-]+/downloads/(en/|.*?displaylang=en)', c: 'inv_c_3331mt13_NEW_751-753.js', f: 0.00054, p: 0 	}
	,{m: '//[\\w\\.-]+/dynamics(/(?!dynamicsresearch.mspx|everyonegetsit)|$)', c: 'inv_c_3331mt14_NEW-750.js', f: 0.108, p: 0 	}
	,{m: '//[\\w\\.-]+/dynamics/asmartmove/default\\.mspx', c: 'inv_c_3331mt14-SL-fix_NEW-750.js', f: 0.108, p: 3 	}
	,{m: '//[\\w\\.-]+/dynamics/default\\.mspx$', c: 'inv_c_3331mt14_flashfix_NEW-750.js', f: 0.108, p: 1 	}
	,{m: '//[\\w\\.-]+/en/au/', c: 'inv_c_p15466742-AU-HP-369.js', f: 0.03, p: 0 	}
	,{m: '//[\\w\\.-]+/en/us/default\\.aspx', c: 'inv_c_p15394611-US-HP.js', f: 0.0054, p: 0 	}
	,{m: '//[\\w\\.-]+/es/es/default\\.aspx', c: 'inv_c_p17637473-ES_HP.js', f: 0.09, p: 0 	}
	,{m: '//[\\w\\.-]+/fr/fr/(default\\.aspx)?$', c: 'inv_c_p15466742-France-HP.js', f: 0.02, p: 0 	}
	,{m: '//[\\w\\.-]+/france/carrieres/', c: 'inv_c_p37116158-FR.js', f: 1, p: 0 	}
	,{m: '//[\\w\\.-]+/france/windows/', c: 'inv_c_p15466742_21.js', f: 0.005, p: 0 	}
	,{m: '//[\\w\\.-]+/germany/branchen/', c: 'inv_c_DE-p15466742-Branchen.js', f: 0.5, p: 0 	}
	,{m: '//[\\w\\.-]+/germany/server(/|$)', c: 'inv_c_DE-wss-p12038685.js', f: 0.2, p: 0 	}
	,{m: '//[\\w\\.-]+/germany/windows(/|$)', c: 'inv_c_DE-windows-p12038685.js', f: 0.002, p: 0 	}
	,{m: '//[\\w\\.-]+/india/careers/', c: 'inv_c_p37116158-IN.js', f: 1, p: 0 	}
	,{m: '//[\\w\\.-]+/italy/beit/', c: 'inv_c_p17637473_788.js', f: 0.47, p: 1 	}
	,{m: '//[\\w\\.-]+/italy/beit/($|default.aspx$|.*video=)', c: 'inv_c_p17637473_788-fix.js', f: 0.47, p: 2 	}
	,{m: '//[\\w\\.-]+/italy/info/career/', c: 'inv_c_p37116158-IT.js', f: 1, p: 0 	}
	,{m: '//[\\w\\.-]+/ja/jp/', c: 'inv_c_p15466742-Japan-HP.js', f: 0.006, p: 0 	}
	,{m: '//[\\w\\.-]+/japan/athome/', c: 'inv_c_JA-p15466742-athome.js', f: 0.0008, p: 0 	}
	,{m: '//[\\w\\.-]+/japan/atwork/', c: 'inv_c_JA-p15466742-atwork.js', f: 0.02, p: 0 	}
	,{m: '//[\\w\\.-]+/japan/business/', c: 'inv_c_JA-p15466742-business.js', f: 0.025, p: 0 	}
	,{m: '//[\\w\\.-]+/japan/careers/', c: 'inv_c_p37116158-JA.js', f: 1, p: 0 	}
	,{m: '//[\\w\\.-]+/japan/servers/', c: 'inv_c_JA-p15466742-servers.js', f: 0.1, p: 0 	}
	,{m: '//[\\w\\.-]+/japan/technet/', c: 'inv_c_JA-p12038685-technet.js', f: 0.002, p: 0 	}
	,{m: '//[\\w\\.-]+/japan/users', c: 'inv_c_JA-p15466742-users.js', f: 0.003, p: 0 	}
	,{m: '//[\\w\\.-]+/japan/users/default\\.mspx$', c: 'inv_c_JA-p15466742-users-Flashfix.js', f: 0.003, p: 1 	}
	,{m: '//[\\w\\.-]+/japan/windows(/(?!(downloads/ie/au\\.mspx)|(downloads/ie/iedelete\\.mspx))|$)', c: 'inv_c_JA-p15466742-windows.js', f: 0.0007, p: 0 	}
	,{m: '//[\\w\\.-]+/japan/windows/(digitallife|possibilities)/', c: 'inv_c_JA-p15466742-windows-digitallife.js', f: 0.0007, p: 1 	}
	,{m: '//[\\w\\.-]+/learning/en/us/(default\\.aspx)?$', c: 'inv_c_3331mt42.js', f: 0.27, p: 0 	}
	,{m: '//[\\w\\.-]+/licensing(/(?!(licensewise/product\\.aspx)|(licensewise/program\\.aspx)|(mla/select\\.aspx)))', c: 'inv_c_3331mt43.js', f: 0.084, p: 0 	}
	,{m: '//[\\w\\.-]+/protect(/(?!computer/updates/bulletins)|$)', c: 'inv_c_3331mt4.js', f: 0.02, p: 0 	}
	,{m: '//[\\w\\.-]+/rus/careers/', c: 'inv_c_p37116158-RU.js', f: 1, p: 0 	}
	,{m: '//[\\w\\.-]+/security', c: 'inv_c_3331mt49.js', f: 0.0236, p: 0 	}
	,{m: '//[\\w\\.-]+/spain', c: 'inv_c_p17637473-ES.js', f: 0.0084, p: 0 	}
	,{m: '//[\\w\\.-]+/sql/experience/(Default\\.aspx\\?loc=en)|(html/Default\\.aspx\\?loc=en)|(html/Events\\.aspx\\?loc=en)|(LearnSQL\\.aspx\\?h=t&loc=en)|(LearnSQL\\.aspx\\?loc=en)|(Events\\.aspx\\?loc=en)|(.*\\.wmv)', c: 'inv_c_blank.js', f: 0, p: 2 	}
	,{m: '//[\\w\\.-]+/(sql|sqlserver)', c: 'inv_c_3331mt52-p37985286-SQL.js', f: 0.07, p: 0 	}
	,{m: '//[\\w\\.-]+/sqlserver/2005/', c: 'inv_c_3331mt52-p37985286-SQL.js', f: 0.07, p: 1 	}
	,{m: '//[\\w\\.-]+/technet/(?!mnp_utility\\.mspx/(framesmenu|quicksearch|masthead)\\?url)', c: 'inv_c_p15808382-p26386365.js', f: 0.004, p: 0 	}
	,{m: '//[\\w\\.-]+/technet/scriptcenter/', c: 'inv_c_p15808382-p26386365-TIER3.js', f: 0.004, p: 1 	}
	,{m: '//[\\w\\.-]+/technet/security/', c: 'inv_c_p15808382-p26386365-TIER2.js', f: 0.004, p: 1 	}
	,{m: '//[\\w\\.-]+/technet/(.*/subscriptions|support|community)/', c: 'inv_c_p15808382mt-technet.js', f: 0.004, p: 1 	}
	,{m: '//[\\w\\.-]+/uk/careers/', c: 'inv_c_p37116158-UK.js', f: 1, p: 0 	}
	,{m: '//[\\w\\.-]+/video/', c: 'inv_c_p23275586.js', f: 0.5, p: 0 	}
	,{m: '//(sr-www|wwwstaging|www\\.microsoft)[\\w\\.-]+/windows/(?!enterprise)', c: 'inv_c_p25328149.js', f: 0.0005117, p: 0 	}
	,{m: '//[\\w\\.-]+/windows/buy/', c: 'inv_c_p25328149-Buy-WLS-p38104477-BUY.js', f: 0.0055, p: 1 	}
	,{m: '//[\\w\\.-]+/windows/buy/windows-laptop-scout\\.aspx$', c: 'inv_c_p25328149-Buy-WLS-p38104477.js', f: 0.2, p: 2 	}
	,{m: '//[\\w\\.-]+/windows/downloads/', c: 'inv_c_p25328149-downloads-p34934647.js', f: 0.0034, p: 1 	}
	,{m: '//[\\w\\.-]+/windows/internet-explorer/(?!welcome\\.aspx)', c: 'inv_c_3331mt62-p25328149.js', f: 0.0015, p: 1 	}
	,{m: '//[\\w\\.-]+/windows/internet-explorer/videos\\.aspx$', c: 'inv_c_3331mt62-p25328149_SL-FIX.js', f: 0.0015, p: 2 	}
	,{m: '//[\\w\\.-]+/windows/possibilities/', c: 'inv_c_p25328149_SL-FIX.js', f: 0.0005117, p: 1 	}
	,{m: '//[\\w\\.-]+/windows/windows-7/', c: 'inv_c_p34934887-p25328149.js', f: 0.008, p: 1 	}
	,{m: '//[\\w\\.-]+/windows/windows-laptop-scout/(default\\.aspx)?$', c: 'inv_c_p25328149_laptop-scout_SL-FIX.js', f: 0.2, p: 1 	}
	,{m: '//[\\w\\.-]+/windows/windows-vista(/|$)', c: 'inv_c_3331mt64-p25328149.js', f: 0.00118, p: 1 	}
	,{m: '//[\\w\\.-]+/windows/windows-vista/discover/', c: 'inv_c_3331mt64-p25328149_SL-FX.js', f: 0.017, p: 2 	}
	,{m: '//[\\w\\.-]+/windowsembedded/en-us/', c: 'inv_c_3331mt174.js', f: 0.5, p: 1 	}
	,{m: '//[\\w\\.-]+/windowsmobile', c: 'inv_c_3331mt173.js', f: 0.00092, p: 0 	}
	,{m: '//[\\w\\.-]+/windowsmobile/en-us/totalaccess/', c: 'inv_c_p30393194_3331mt173.js', f: 0.00264, p: 1 	}
]
};
COMSCORE.SiteRecruit.Broker.run();