package main

import (
	"bytes"
	"fmt"
	"log"
	"net/http"
	"os"
	"time"

	"github.com/rs/cors"
)

func main() {
	mux := http.NewServeMux()

	mux.HandleFunc("/", func(w http.ResponseWriter, r *http.Request) {
		fmt.Fprintln(w, "Hello, World!")
	})

	mux.HandleFunc("GET /api/source/mp3/{filename}", func(w http.ResponseWriter, r *http.Request) {
		fmt.Println(r.PathValue("filename"))
		audioFile, err := os.ReadFile("./source/mp3/" + r.PathValue("filename"))

		if err != nil {
			log.Println(err)
			return
		}

		w.Header().Set("Access-Control-Allow-Origin", "*")
		w.Header().Set("Content-Type", "audio/mpeg")
		audioChunks := bytes.NewBuffer(audioFile)

		if _, err := audioChunks.WriteTo(w); err != nil {
			log.Println(err)
		}
	})

	mux.HandleFunc("GET /api/source/png/{filename}", func(w http.ResponseWriter, r *http.Request) {

		fmt.Println(r.PathValue("filename"))
		imageFile, err := os.ReadFile("./source/png/" + r.PathValue("filename"))

		if err != nil {
			log.Println(err)
			return
		}

		w.Header().Set("Access-Control-Allow-Origin", "*")
		w.Header().Set("Content-Type", "image/png")
		imageChunks := bytes.NewBuffer(imageFile)

		if _, err := imageChunks.WriteTo(w); err != nil {
			log.Println(err)
		}
	})

	c := cors.New(cors.Options{
		AllowedOrigins: []string{"*"},
		AllowedHeaders: []string{"*"},
		AllowedMethods: []string{"GET", "POST", "PUT", "DELETE", "HEAD", "PATCH"},
	})

	handler := c.Handler(mux)

	server := &http.Server{
		Addr:         ":1444",
		Handler:      handler,
		ReadTimeout:  10 * time.Second,
		WriteTimeout: 10 * time.Second,
	}

	log.Fatal(server.ListenAndServe())

	//todo
	//! go to an https server
	//? patch for http is in androidmanifest.xml
	//? <application android:usesCleartextTraffic="true">
	//? bad from a security standpoint
	//* but it works sooooo... yah
}
