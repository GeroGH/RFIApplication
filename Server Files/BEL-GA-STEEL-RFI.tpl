
template _tmp_4144
{
    name = "template3";
    type = GRAPHICAL;
    width = 195;
    maxheight = 5000;
    columns = (1, 1);
    gap = 5;
    fillpolicy = EVEN;
    filldirection = HORIZONTAL;
    fillstartfrom = TOPLEFT;
    margins = (0, 0, 0, 0);
    gridxspacing = 1;
    gridyspacing = 1;
    version = 3.6;
    created = "26.06.2007 11:21";
    modified = "16.11.2021 14:07";
    notes = "An SPH Creation";

    pageheader _tmp_171
    {
        name = "PageHeader";
        height = 6;
        outputpolicy = NONE;

        lineorarc _tmp_178
        {
            name = "LineOrArc";
            x1 = 2;
            y1 = 1;
            x2 = 6;
            y2 = 1;
            pen = -1;
            color = 164;
            linetype = 1;
            linewidth = 1;
            bulge = 0;
        };

        text _tmp_179
        {
            name = "Text_7";
            x1 = 2.02456058782991;
            y1 = 2;
            x2 = 2.02456058782991;
            y2 = 2;
            string = "RFI:";
            fontname = "Arial";
            fontcolor = 153;
            fonttype = 2;
            fontsize = 2.3;
            fontratio = 0.8;
            fontslant = 0;
            fontstyle = 1;
            angle = 0;
            justify = CENTERED;
            pen = 0;
        };

        lineorarc _tmp_7
        {
            name = "LineOrArc_3";
            x1 = 183.406259364146;
            y1 = 1;
            x2 = 189.906259364146;
            y2 = 1;
            pen = -1;
            color = 164;
            linetype = 1;
            linewidth = 1;
            bulge = 0;
        };

        text _tmp_5
        {
            name = "Text_2";
            x1 = 163;
            y1 = 2;
            x2 = 163;
            y2 = 2;
            string = "Phase:";
            fontname = "Arial";
            fontcolor = 153;
            fonttype = 2;
            fontsize = 2.3;
            fontratio = 0.8;
            fontslant = 0;
            fontstyle = 1;
            angle = 0;
            justify = CENTERED;
            pen = 0;
        };

        lineorarc _tmp_6
        {
            name = "LineOrArc_2";
            x1 = 163;
            y1 = 1;
            x2 = 172;
            y2 = 1;
            pen = -1;
            color = 164;
            linetype = 1;
            linewidth = 1;
            bulge = 0;
        };

        text _tmp_9
        {
            name = "Text";
            x1 = 53;
            y1 = 2;
            x2 = 53;
            y2 = 2;
            string = "Subject:";
            fontname = "Arial";
            fontcolor = 153;
            fonttype = 2;
            fontsize = 2.3;
            fontratio = 0.8;
            fontslant = 0;
            fontstyle = 1;
            angle = 0;
            justify = CENTERED;
            pen = 0;
        };

        lineorarc _tmp_10
        {
            name = "LineOrArc_1";
            x1 = 53;
            y1 = 1;
            x2 = 62;
            y2 = 1;
            pen = -1;
            color = 164;
            linetype = 1;
            linewidth = 1;
            bulge = 0;
        };

        text _tmp_18
        {
            name = "Text_3";
            x1 = 183.163671954535;
            y1 = 2;
            x2 = 183.163671954535;
            y2 = 2;
            string = "Parts";
            fontname = "Arial";
            fontcolor = 153;
            fonttype = 2;
            fontsize = 2.3;
            fontratio = 1;
            fontslant = 0;
            fontstyle = 1;
            angle = 0;
            justify = CENTERED;
            pen = 0;
        };
    };

    row _tmp_14
    {
        name = "1st";
        height = 2;
        visibility = TRUE;
        usecolumns = FALSE;
        rule = "";
        contenttype = "";
        sorttype = COMBINE;

        lineorarc _tmp_15
        {
            name = "LineOrArc_6";
            x1 = 2;
            y1 = 1;
            x2 = 191;
            y2 = 1;
            pen = -1;
            color = 164;
            linetype = 1;
            linewidth = 1;
            bulge = 0;
        };
    };

    row _tmp_4169
    {
        name = "1 line";
        height = 4;
        visibility = TRUE;
        usecolumns = FALSE;
        rule = "if match(GetValue(\"RFIcombined\"),\"*,*\") == 0 && GetValue(\"RFIcombined\") >0 then\n  Output()\nelse\n  StepOver()\nendif";
        contenttype = "ASSEMBLY";
        sorttype = COMBINE;

        valuefield _tmp_2
        {
            name = "phase";
            location = (163, 1);
            formula = "GetValue(\"PHASE\")";
            maxnumoflines = 1;
            datatype = STRING;
            class = "";
            cacheable = TRUE;
            formatzeroasempty = FALSE;
            justify = LEFT;
            visibility = TRUE;
            angle = 0;
            length = 10;
            decimals = 0;
            sortdirection = ASCENDING;
            fontname = "Arial";
            fontcolor = 153;
            fonttype = 2;
            fontsize = 2.3;
            fontratio = 1;
            fontstyle = 0;
            fontslant = 0;
            pen = 0;
            oncombine = NONE;
            fontlinewidth = 1;
        };

        valuefield _tmp_243
        {
            name = "label";
            location = (2, 0.99489259566605);
            formula = "GetValue(\"RFIcombined\")";
            maxnumoflines = 1;
            datatype = STRING;
            class = "";
            cacheable = TRUE;
            formatzeroasempty = FALSE;
            justify = LEFT;
            visibility = TRUE;
            angle = 0;
            length = 30;
            decimals = 0;
            sortdirection = ASCENDING;
            fontname = "Arial";
            fontcolor = 153;
            fonttype = 2;
            fontsize = 2.3;
            fontratio = 1;
            fontstyle = 0;
            fontslant = 0;
            pen = 0;
            oncombine = NONE;
            fontlinewidth = 1;
        };

        valuefield _tmp_245
        {
            name = "rs1";
            location = (51, 0.99489259566605);
            formula = "if match(GetValue(\"RFIcombined\"),GetValue(\"RFI1\")) == 1 then\nGetValue(\"RFI1Subject\") else\n\nif match(GetValue(\"RFIcombined\"),GetValue(\"RFI2\")) == 1 then\nGetValue(\"RFI2Subject\") else\n\nif match(GetValue(\"RFIcombined\"),GetValue(\"RFI3\")) == 1 then\nGetValue(\"RFI3Subject\") else\n\nif match(GetValue(\"RFIcombined\"),GetValue(\"RFI4\")) == 1 then\nGetValue(\"RFI4Subject\") else\n\nif match(GetValue(\"RFIcombined\"),GetValue(\"RFI5\")) == 1 then\nGetValue(\"RFI5Subject\") else\n\nif match(GetValue(\"RFIcombined\"),GetValue(\"RFI6\")) == 1 then\nGetValue(\"RFI6Subject\") else\n\nif match(GetValue(\"RFIcombined\"),GetValue(\"RFI7\")) == 1 then\nGetValue(\"RFI7Subject\") else\n\nif match(GetValue(\"RFIcombined\"),GetValue(\"RFI8\")) == 1 then\nGetValue(\"RFI8Subject\") else\n\nif match(GetValue(\"RFIcombined\"),GetValue(\"RFI9\")) == 1 then\nGetValue(\"RFI9Subject\") else\n\nif match(GetValue(\"RFIcombined\"),GetValue(\"RFI10\")) == 1 then\nGetValue(\"RFI10Subject\") else\n\nendif\nendif\nendif\nendif\nendif\nendif\nendif\nendif\nendif\nendif";
            maxnumoflines = 1;
            datatype = STRING;
            class = "";
            cacheable = TRUE;
            formatzeroasempty = FALSE;
            justify = LEFT;
            visibility = TRUE;
            angle = 0;
            length = 70;
            decimals = 0;
            sortdirection = NONE;
            fontname = "Arial";
            fontcolor = 153;
            fonttype = 2;
            fontsize = 2.3;
            fontratio = 1;
            fontstyle = 0;
            fontslant = 0;
            pen = 0;
            oncombine = NONE;
            fontlinewidth = 1;
        };

        valuefield _tmp_1
        {
            name = "no";
            location = (184, 0.99489259566605);
            formula = "GetValue(\"NUMBER\")";
            maxnumoflines = 1;
            datatype = INTEGER;
            class = "";
            cacheable = TRUE;
            formatzeroasempty = FALSE;
            justify = CENTERED;
            visibility = TRUE;
            angle = 0;
            length = 4;
            decimals = 0;
            sortdirection = NONE;
            fontname = "Arial";
            fontcolor = 153;
            fonttype = 2;
            fontsize = 2.3;
            fontratio = 1;
            fontstyle = 0;
            fontslant = 0;
            pen = 0;
            oncombine = SUM;
            fontlinewidth = 1;
        };
    };

    row _tmp_2
    {
        name = "2nd";
        height = 2;
        visibility = TRUE;
        usecolumns = FALSE;
        rule = "";
        contenttype = "";
        sorttype = COMBINE;

        lineorarc _tmp_5
        {
            name = "LineOrArc_4";
            x1 = 2;
            y1 = 1;
            x2 = 191;
            y2 = 1;
            pen = -1;
            color = 164;
            linetype = 1;
            linewidth = 1;
            bulge = 0;
        };
    };

    row _tmp_147
    {
        name = "2 lines";
        height = 4;
        visibility = TRUE;
        usecolumns = FALSE;
        rule = "if match(GetValue(\"RFIcombined\"),\"*,*\") == 1 && GetValue(\"RFIcombined\") > 0 then\n  Output()\nelse\n  StepOver()\nendif";
        contenttype = "ASSEMBLY";
        sorttype = COMBINE;

        valuefield _tmp_14
        {
            name = "mphase";
            location = (163, 1);
            formula = "GetValue(\"PHASE\")";
            maxnumoflines = 1;
            datatype = STRING;
            class = "";
            cacheable = TRUE;
            formatzeroasempty = FALSE;
            justify = LEFT;
            visibility = TRUE;
            angle = 0;
            length = 10;
            decimals = 0;
            sortdirection = ASCENDING;
            fontname = "Arial";
            fontcolor = 153;
            fonttype = 2;
            fontsize = 2.3;
            fontratio = 1;
            fontstyle = 0;
            fontslant = 0;
            pen = 0;
            oncombine = NONE;
            fontlinewidth = 1;
        };

        valuefield _tmp_6
        {
            name = "mlabelirs";
            location = (2, 0.800376631886399);
            formula = "GetValue(\"RFIcombined\")";
            maxnumoflines = 1;
            datatype = STRING;
            class = "";
            cacheable = TRUE;
            formatzeroasempty = FALSE;
            justify = LEFT;
            visibility = TRUE;
            angle = 0;
            length = 30;
            decimals = 0;
            sortdirection = ASCENDING;
            fontname = "Arial";
            fontcolor = 153;
            fonttype = 2;
            fontsize = 2.3;
            fontratio = 1;
            fontstyle = 0;
            fontslant = 0;
            pen = 0;
            oncombine = NONE;
            fontlinewidth = 1;
        };

        valuefield _tmp_3
        {
            name = "mno";
            location = (184, 0.8963408316406);
            formula = "GetValue(\"NUMBER\")";
            maxnumoflines = 1;
            datatype = INTEGER;
            class = "";
            cacheable = TRUE;
            formatzeroasempty = FALSE;
            justify = CENTERED;
            visibility = TRUE;
            angle = 0;
            length = 4;
            decimals = 0;
            sortdirection = NONE;
            fontname = "Arial";
            fontcolor = 153;
            fonttype = 2;
            fontsize = 2.3;
            fontratio = 1;
            fontstyle = 0;
            fontslant = 0;
            pen = 0;
            oncombine = SUM;
            fontlinewidth = 1;
        };

        text _tmp_1
        {
            name = "Text_1";
            x1 = 51;
            y1 = 1;
            x2 = 51;
            y2 = 1;
            string = "Multiple RFI's please, see IRS sheet";
            fontname = "Arial";
            fontcolor = 153;
            fonttype = 2;
            fontsize = 2.3;
            fontratio = 1;
            fontslant = 0;
            fontstyle = 0;
            angle = 0;
            justify = CENTERED;
            pen = 0;
        };
    };

    row _tmp_12
    {
        name = "3rd";
        height = 2;
        visibility = TRUE;
        usecolumns = FALSE;
        rule = "";
        contenttype = "";
        sorttype = COMBINE;

        lineorarc _tmp_13
        {
            name = "LineOrArc_5";
            x1 = 2;
            y1 = 1;
            x2 = 191;
            y2 = 1;
            pen = -1;
            color = 164;
            linetype = 1;
            linewidth = 1;
            bulge = 0;
        };
    };
};
