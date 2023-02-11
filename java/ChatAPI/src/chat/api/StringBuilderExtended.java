package chat.api;

public class StringBuilderExtended {
    public static <T> StringBuilder appendArray(StringBuilder b,T[] array){
        for (int i = 0; i < array.length; i++) {
            b.append(array[i]);
        }
        return b;
    }
    public static <T, TSep> StringBuilder appendArray(StringBuilder b,T[] array, TSep separator){
        if(array.length==0) return b;
        b.append(array[0]);
        for (int i = 1; i < array.length-1; i++)
            b.append(separator).append(array[i]);
        return b;
    }

    public static <T> StringBuilder appendIterable(StringBuilder b, Iterable<T> iterable){
        for (T t : iterable)
            b.append(t);
        return b;
    }
    public static <T, TSep> StringBuilder appendIterable(StringBuilder b, Iterable<T> iterable, TSep separator){
        var iterator=iterable.iterator();
        if(!iterator.hasNext()) return b;
        b.append(iterator.next());
        while (iterator.hasNext())
            b.append(separator).append(iterator.next());
        return b;
    }
}
