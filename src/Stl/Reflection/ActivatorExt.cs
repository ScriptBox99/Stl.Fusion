using System.Reflection.Emit;
using Stl.Internal;

namespace Stl.Reflection;

public static class ActivatorExt
{
    private static readonly ConcurrentDictionary<Type, bool> HasDefaultCtorCache = new();
    private static readonly ConcurrentDictionary<Type, Delegate?> CtorDelegate0Cache = new();
    private static readonly ConcurrentDictionary<(Type, Type), Delegate?> CtorDelegate1Cache = new();
    private static readonly ConcurrentDictionary<(Type, Type, Type), Delegate?> CtorDelegate2Cache = new();
    private static readonly ConcurrentDictionary<(Type, Type, Type, Type), Delegate?> CtorDelegate3Cache = new();
    private static readonly ConcurrentDictionary<(Type, Type, Type, Type, Type), Delegate?> CtorDelegate4Cache = new();
    private static readonly ConcurrentDictionary<(Type, Type, Type, Type, Type, Type), Delegate?> CtorDelegate5Cache = new();

    // An alternative to "new()" constraint
    public static T New<T>(bool failIfNoDefaultConstructor = true)
    {
        var type = typeof(T);
        if (type.IsValueType)
            return default!;
        var hasDefaultCtor = HasDefaultCtorCache.GetOrAdd(type,
            type1 => type1.GetConstructor(Type.EmptyTypes) != null);
        if (hasDefaultCtor)
            return (T)type.CreateInstance();
        if (failIfNoDefaultConstructor)
            throw Errors.NoDefaultConstructor(type);
        return default!;
    }

    public static Delegate? GetConstructorDelegate(this Type type)
        => CtorDelegate0Cache.GetOrAdd(
            type,
            static tObject => {
                var argTypes = Type.EmptyTypes;
                var ctor = tObject.GetConstructor(argTypes);
                if (ctor == null) return null;

                var m = new DynamicMethod("_Create0", tObject, Type.EmptyTypes, true);
                var il = m.GetILGenerator();
                il.Emit(OpCodes.Newobj, ctor);
                il.Emit(OpCodes.Ret);
                return m.CreateDelegate(typeof(Func<>).MakeGenericType(tObject));
            });

    public static Delegate? GetConstructorDelegate(this Type type, Type argument1)
        => CtorDelegate1Cache.GetOrAdd(
            (type, argument1),
            static key => {
                var (tObject, tArg1) = key;
                var ctor = tObject.GetConstructor(new[] { tArg1 });
                if (ctor == null) return null;

                var m = new DynamicMethod("_Create1", tObject, new[] { tArg1 }, true);
                var il = m.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Newobj, ctor);
                il.Emit(OpCodes.Ret);
                return m.CreateDelegate(typeof(Func<,>).MakeGenericType(tArg1, tObject));
            });

    public static Delegate? GetConstructorDelegate(this Type type, Type argument1, Type argument2)
        => CtorDelegate2Cache.GetOrAdd(
            (type, argument1, argument2),
            static key => {
                var (tObject, tArg1, tArg2) = key;
                var ctor = tObject.GetConstructor(new[] { tArg1, tArg2 });
                if (ctor == null) return null;

                var m = new DynamicMethod("_Create2", tObject, new[] { tArg1, tArg2 }, true);
                var il = m.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Newobj, ctor);
                il.Emit(OpCodes.Ret);
                return m.CreateDelegate(typeof(Func<,,>).MakeGenericType(tArg1, tArg2, tObject));
            });

    public static Delegate? GetConstructorDelegate(this Type type, Type argument1, Type argument2, Type argument3)
        => CtorDelegate3Cache.GetOrAdd(
            (type, argument1, argument2, argument3),
            static key => {
                var (tObject, tArg1, tArg2, tArg3) = key;
                var ctor = tObject.GetConstructor(new[] { tArg1, tArg2, tArg3 });
                if (ctor == null) return null;

                var m = new DynamicMethod("_Create3", tObject, new[] { tArg1, tArg2, tArg3 }, true);
                var il = m.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Newobj, ctor);
                il.Emit(OpCodes.Ret);
                return m.CreateDelegate(typeof(Func<,,,>).MakeGenericType(tArg1, tArg2, tArg3, tObject));
            });

    public static Delegate? GetConstructorDelegate(this Type type,
        Type argument1, Type argument2, Type argument3, Type argument4)
        => CtorDelegate4Cache.GetOrAdd(
            (type, argument1, argument2, argument3, argument4),
            static key => {
                var (tObject, tArg1, tArg2, tArg3, tArg4) = key;
                var ctor = tObject.GetConstructor(new[] { tArg1, tArg2, tArg3, tArg4 });
                if (ctor == null) return null;

                var m = new DynamicMethod("_Create4", tObject, new[] { tArg1, tArg2, tArg3, tArg4 }, true);
                var il = m.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Ldarg_3);
                il.Emit(OpCodes.Newobj, ctor);
                il.Emit(OpCodes.Ret);
                return m.CreateDelegate(typeof(Func<,,,,>).MakeGenericType(tArg1, tArg2, tArg3, tArg4, tObject));
            });

    public static Delegate? GetConstructorDelegate(this Type type,
        Type argument1, Type argument2, Type argument3, Type argument4, Type argument5)
        => CtorDelegate5Cache.GetOrAdd(
            (type, argument1, argument2, argument3, argument4, argument5),
            static key => {
                var (tObject, tArg1, tArg2, tArg3, tArg4, tArg5) = key;
                var ctor = tObject.GetConstructor(new[] { tArg1, tArg2, tArg3, tArg4, tArg5 });
                if (ctor == null) return null;

                var m = new DynamicMethod("_Create5", tObject, new[] { tArg1, tArg2, tArg3, tArg4, tArg5 }, true);
                var il = m.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Ldarg_3);
                il.Emit(OpCodes.Ldarg, 4);
                il.Emit(OpCodes.Newobj, ctor);
                il.Emit(OpCodes.Ret);
                return m.CreateDelegate(typeof(Func<,,,,,>).MakeGenericType(tArg1, tArg2, tArg3, tArg4, tArg5, tObject));
            });

    public static object CreateInstance(this Type type)
    {
        var ctor = (Func<object>) type.GetConstructorDelegate()!;
        return ctor.Invoke();
    }

    public static object CreateInstance<T1>(this Type type, T1 argument1)
    {
        var ctor = (Func<T1, object>) type.GetConstructorDelegate(typeof(T1))!;
        return ctor.Invoke(argument1);
    }

    public static object CreateInstance<T1, T2>(this Type type, T1 argument1, T2 argument2)
    {
        var ctor = (Func<T1, T2, object>) type.GetConstructorDelegate(typeof(T1), typeof(T2))!;
        return ctor.Invoke(argument1, argument2);
    }

    public static object CreateInstance<T1, T2, T3>(this Type type, T1 argument1, T2 argument2, T3 argument3)
    {
        var ctor = (Func<T1, T2, T3, object>) type.GetConstructorDelegate(typeof(T1), typeof(T2), typeof(T3))!;
        return ctor.Invoke(argument1, argument2, argument3);
    }

    public static object CreateInstance<T1, T2, T3, T4>(this Type type, T1 argument1, T2 argument2, T3 argument3, T4 argument4)
    {
        var ctor = (Func<T1, T2, T3, T4, object>) type.GetConstructorDelegate(typeof(T1), typeof(T2), typeof(T3), typeof(T4))!;
        return ctor.Invoke(argument1, argument2, argument3, argument4);
    }

    public static object CreateInstance<T1, T2, T3, T4, T5>(this Type type, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5)
    {
        var ctor = (Func<T1, T2, T3, T4, T5, object>) type.GetConstructorDelegate(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5))!;
        return ctor.Invoke(argument1, argument2, argument3, argument4, argument5);
    }
}
