using System;
using System.Windows.Input;

namespace Reserveroom.viewModels;

public class RelayCommand : ICommand
{
    private readonly Action<object?> _execute;

    public RelayCommand(Action execute)
    {
        _execute = _ => execute();
    }

    public RelayCommand(Action<object?> execute)
    {
        _execute = execute;
    }

    public bool CanExecute(object? parameter) => true;
    public void Execute(object? parameter) => _execute(parameter);
    public event EventHandler? CanExecuteChanged;
}
