function myPages(pageindex, rowscount) {
    var pagesize = 3;
    var pagecount = 0;
    var pagenext = 0;
    var pagepre = 0;
    var pagelast = 0;

    pagecount = Math.ceil(rowscount / pagesize);
    pagepre = parseInt(pageindex) > 1 ? parseInt(pageindex) - 1 : 1;
    pagenext = parseInt(pageindex) >= pagecount ? pagecount : parseInt(pageindex) + 1;
    pagelast = pagecount;

    var pages = '';
    pages += '<span class="btn-danger" onclick="pageclick(\'1\');">首页</span>';
    pages += '<span class="btn-danger" onclick="pageclick(\'' + pagepre + '\');">上一页</span>';

    pages += '<span class="btn-danger" onclick="pageclick(\'' + pagenext + '\');">下一页</span>';
    pages += '<span class="btn-danger" onclick="pageclick(\'' + pagelast + '\');">尾页</span>';
    $('.pages').html(pages);

}