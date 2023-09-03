﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Snap.Hutao.Model.Entity;
using Snap.Hutao.Model.InterChange.GachaLog;
using Snap.Hutao.Service.GachaLog.QueryProvider;
using Snap.Hutao.ViewModel.GachaLog;
using System.Collections.ObjectModel;

namespace Snap.Hutao.Service.GachaLog;

/// <summary>
/// 祈愿记录服务
/// </summary>
[HighQuality]
internal interface IGachaLogService
{
    /// <summary>
    /// 当前存档
    /// </summary>
    GachaArchive? CurrentArchive { get; set; }

    /// <summary>
    /// 获取可用于绑定的存档集合
    /// </summary>
    ObservableCollection<GachaArchive>? ArchiveCollection { get; }

    ValueTask<GachaArchive> EnsureArchiveInCollectionAsync(Guid archiveId, CancellationToken token = default(CancellationToken));

    /// <summary>
    /// 导出为一个新的UIGF对象
    /// </summary>
    /// <param name="archive">存档</param>
    /// <returns>UIGF对象</returns>
    ValueTask<UIGF> ExportToUIGFAsync(GachaArchive archive);

    /// <summary>
    /// 获得对应的祈愿统计
    /// </summary>
    /// <param name="archive">存档</param>
    /// <returns>祈愿统计</returns>
    ValueTask<GachaStatistics> GetStatisticsAsync(GachaArchive? archive);

    /// <summary>
    /// 异步获取简化的祈愿统计列表
    /// </summary>
    /// <param name="token">取消令牌</param>
    /// <returns>简化的祈愿统计列表</returns>
    ValueTask<List<GachaStatisticsSlim>> GetStatisticsSlimListAsync(CancellationToken token = default);

    /// <summary>
    /// 异步从UIGF导入数据
    /// </summary>
    /// <param name="uigf">信息</param>
    /// <returns>任务</returns>
    ValueTask ImportFromUIGFAsync(UIGF uigf);

    /// <summary>
    /// 异步初始化
    /// </summary>
    /// <param name="token">取消令牌</param>
    /// <returns>是否初始化成功</returns>
    ValueTask<bool> InitializeAsync(CancellationToken token = default);

    /// <summary>
    /// 刷新祈愿记录
    /// 切换选中的存档
    /// </summary>
    /// <param name="query">查询语句</param>
    /// <param name="strategy">刷新策略</param>
    /// <param name="progress">进度</param>
    /// <param name="token">取消令牌</param>
    /// <returns>验证密钥是否有效</returns>
    ValueTask<bool> RefreshGachaLogAsync(GachaLogQuery query, RefreshStrategy strategy, IProgress<GachaLogFetchStatus> progress, CancellationToken token);

    /// <summary>
    /// 删除存档
    /// </summary>
    /// <param name="archive">存档</param>
    /// <returns>任务</returns>
    ValueTask RemoveArchiveAsync(GachaArchive archive);
}