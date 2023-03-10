namespace WPF_46731r.Domain.Models.Abstractions;

public interface ITreeItem
{
    bool IsExpanded { get; set; }
    bool IsSelected { get; set; }
}