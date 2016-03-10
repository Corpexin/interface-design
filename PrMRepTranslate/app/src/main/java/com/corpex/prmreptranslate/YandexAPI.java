package com.corpex.prmreptranslate;

/**
 * Created by corpex, by the Grace of God on 01/03/2016.
 */
import retrofit2.Call;
import retrofit2.GsonConverterFactory;
import retrofit2.Retrofit;
import retrofit2.http.GET;
import retrofit2.http.Query;


public class YandexAPI{
    private static final String BASE_URL = "https://translate.yandex.net/api/v1.5/tr.json/";
    private static YandexAPI mInstance;
    private final RetrofitInterface service;

    public interface RetrofitInterface{
        @GET("translate")
        Call<String> getTraduccion(@Query("key") String key ,@Query("lang") String lenguageCode, @Query("text") String text);
    }

    private YandexAPI(){
        Retrofit retrofit = new Retrofit.Builder().baseUrl(BASE_URL).addConverterFactory(GsonConverterFactory.create()).build();
        service = retrofit.create(RetrofitInterface.class);
    }

    public static synchronized YandexAPI getmInstance() {
        if(mInstance == null)
            mInstance = new YandexAPI();

        return mInstance;
    }
    public RetrofitInterface getServicio(){
        return service;
    }
}